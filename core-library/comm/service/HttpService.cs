using System;

namespace Tete.Comm.Service
{

  public class HttpService : ServiceRequest
  {

    #region "Public Variables"

    public string Method;

    #endregion

    #region Constructors

    public HttpService()
      : base()
    {

    }

    public HttpService(string module, string service)
      : base(module, service)
    {

    }

    #endregion

  }

}