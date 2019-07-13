using System;

namespace Tete.Comm.Service
{

  public class ServiceModel
  {

    #region "Public Variables"
    
    public string url;
    public string name;

    #endregion

    #region Constructors
    
    // Empty Constructor
    public ServiceModel()
    {
      this.url = string.Empty;
      this.name = string.Empty;
    }

    // Base Constructor
    public ServiceModel(string url, string name) {
      this.url = url;
      this.name = name;
    }
    
  }
  #endregion

}