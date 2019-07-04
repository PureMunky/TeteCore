using System;

namespace Comm.Service
{

  public class ServiceResponse
  {

    #region "Public Variables"

    public ServiceRequest Request;
    public bool FromCache;

    #endregion

    #region Constructors

    public ServiceResponse(ServiceRequest request)
    {
      this.Request = request;
      this.FromCache = false;
    }

    #endregion
  }
}