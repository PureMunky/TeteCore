using System;

namespace Comm.Service
{

  public class ServiceModel
  {

    #region "Public Variables"
    
    public string url;
    public string name;

    #endregion

    #region Constructors
    public ServiceModel()
    {
      this.url = string.Empty;
      this.name = string.Empty;
    }
  }
  #endregion

}