using System;

namespace Comm.Service
{

  public class ServiceResponse
  {

    #region "Public Variables"

    public ServiceRequest Request;

    #endregion

    #region Constructors

    public ServiceResponse(ServiceRequest request)
    {
      this.Request = request;
    }

    #endregion
  }
}