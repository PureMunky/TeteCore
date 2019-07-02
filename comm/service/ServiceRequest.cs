using System;

namespace Comm.Service
{

  public class ServiceRequest
  {

    #region "Public Variables"

    public string Module;
    public string Service;
    public string Method;

    #endregion

    #region Constructors

    public ServiceRequest()
    {
      this.Module = string.Empty;
      this.Service = string.Empty;
    }

    public ServiceRequest(string module, string service)
    {
      this.Module = module;
      this.Service = service;
    }

    #endregion

  }

}