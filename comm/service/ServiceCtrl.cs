using System;

namespace Comm.Service
{

  public class ServiceCtrl
  {

    private Cache.CacheContract defaultContract = new Cache.CacheContract();
    
    public ServiceResponse Invoke(ServiceRequest request)
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
      catch (Cache.CacheException e)
      {
        cached = false;
      }

      if(!cached)
      {
        response = SendRequest(request);
        Cache.CacheStore.Save(cacheKey, response, defaultContract);
      }

      return response;
    }

    private ServiceResponse SendRequest(ServiceRequest request)
    {
      ServiceResponse response = new ServiceResponse(request);
      
      return response;
    }
  }

}