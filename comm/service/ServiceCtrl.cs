using System;
using System.Threading.Tasks;

namespace Comm.Service
{

  public class ServiceCtrl
  {

    #region "Private Variables"

    private readonly HttpClientService client;

    #endregion

    #region Constructors

    public ServiceCtrl()
    {
      this.client = new HttpClientService();
    }

    public ServiceCtrl(HttpClientService client)
    {
      this.client = client;
    }

    #endregion

    private Cache.CacheContract defaultContract = new Cache.CacheContract();

    public async Task<ServiceResponse> Invoke(ServiceRequest request)
    {
      ServiceResponse response = null;
      string cacheKey = String.Format("Request.{0}.{1}.{2}", request.Module, request.Service, request.Method);
      bool cached = false;
      try
      {
        response = (ServiceResponse)Cache.CacheStore.Retrieve(cacheKey);
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
        Cache.CacheStore.Save(cacheKey, response, defaultContract);
      }

      return response;
    }

    private async Task<ServiceResponse> SendRequest(ServiceRequest request)
    {
      ServiceResponse response = new ServiceResponse(request);
      response.Body = await client.GetStringAsync("http://www.google.com");

      return response;
    }
  }

}