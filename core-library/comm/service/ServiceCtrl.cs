using System;
using System.Threading.Tasks;

namespace Tete.Comm.Service
{

  public class ServiceCtrl : IServiceCtrl
  {

    #region "Private Variables"

    private readonly HttpClientService client;
    private readonly Cache.ICacheStore cacheStore;
    
    private Cache.CacheContract defaultContract = new Cache.CacheContract();
    private const string SERVICE_TEMPLATE = "Service.{0}.{1}";
    private const string REQUEST_TEMPLATE = "Request.{0}.{1}.{2}";
    

    #endregion

    #region Constructors

    public ServiceCtrl()
    {
      this.client = new HttpClientService();
      this.cacheStore = new Cache.CacheStore();
    }

    public ServiceCtrl(HttpClientService client, Cache.ICacheStore cacheStore)
    {
      this.client = client;
      this.cacheStore = cacheStore;
    }

    #endregion

    #region "Public Functions"

    public ServiceResponse Invoke(ServiceRequest request)
    {
      ServiceResponse rtnResponse = new ServiceResponse(request){ Body = "Error" };
      object service = new object{};
      try
      {
        service = this.cacheStore.Retrieve(String.Format(SERVICE_TEMPLATE, request.Module, request.Service));
      }
      catch(Exception)
      {
        rtnResponse.Body = "Requested service doesn't exist.";
      }

      HttpService hs = service as HttpService;
      FunctionService fs = service as FunctionService;

      if (hs != null) { rtnResponse = Invoke(hs).Result; }
      else if (fs != null) { rtnResponse = Invoke(fs); }

      return rtnResponse;
    }

    public void RegisterService(HttpService service)
    {
      this.cacheStore.Save(String.Format(SERVICE_TEMPLATE, service.Module, service.Service), service);
    }
    public void RegisterService(FunctionService service)
    {
      this.cacheStore.Save(String.Format(SERVICE_TEMPLATE, service.Module, service.Service), service);
    }

    public async Task<ServiceResponse> Invoke(HttpService request)
    {
      ServiceResponse response = null;
      string cacheKey = String.Format(REQUEST_TEMPLATE, request.Module, request.Service, request.Method);
      bool cached = false;
      try
      {
        response = (ServiceResponse)this.cacheStore.Retrieve(cacheKey);
        response.FromCache = true;
        cached = true;
      }
      catch (Cache.CacheException)
      {
        cached = false;
      }

      if (!cached)
      {
        response = await SendRequest(request);
        this.cacheStore.Save(cacheKey, response, defaultContract);
      }

      return response;
    }

    public ServiceResponse Invoke(FunctionService request)
    {
      ServiceResponse response = null;
      string cacheKey = String.Format(REQUEST_TEMPLATE, request.Module, request.Service, request.ProcessingFunction.ToString());
      bool cached = false;
      try
      {
        response = (ServiceResponse)this.cacheStore.Retrieve(cacheKey);
        response.FromCache = true;
        cached = true;
      }
      catch (Cache.CacheException)
      {
        cached = false;
      }

      if (!cached)
      {
        response = request.ProcessingFunction(request);
        this.cacheStore.Save(cacheKey, response, defaultContract);
      }

      return response;
    }

    #endregion

    #region "Private Functions"

    private async Task<ServiceResponse> SendRequest(ServiceRequest request)
    {
      ServiceResponse response = new ServiceResponse(request);
      response.Body = await client.GetStringAsync("http://www.google.com");

      return response;
    }

    #endregion
  }

}