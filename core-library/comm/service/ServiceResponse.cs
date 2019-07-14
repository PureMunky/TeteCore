using System;

namespace Tete.Comm.Service
{

  public class ServiceResponse
  {

    #region "Public Variables"

    public ServiceRequest Request;
    public bool FromCache;
    public string Body;

    #endregion

    #region Constructors

    public ServiceResponse(ServiceRequest request)
    {
      this.Request = request;
      this.FromCache = false;
      this.Body = string.Empty;
    }

    #endregion
  }
}