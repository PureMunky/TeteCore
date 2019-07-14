using System;

namespace Tete.Comm.Service
{

  public class FunctionService : ServiceRequest
  {

    #region "Public Delegates"

    public delegate ServiceResponse ProcessRequest(ServiceRequest request);
    
    #endregion

    #region "Public Variables"

    public ProcessRequest ProcessingFunction;

    #endregion

    #region Constructors

    public FunctionService()
      : base()
    {
      this.Module = string.Empty;
      this.Service = string.Empty;
    }

    public FunctionService(string module, string service, ProcessRequest processingFunction)
      : base(module, service)
    {
      this.ProcessingFunction = processingFunction;
    }

    #endregion

  }

}