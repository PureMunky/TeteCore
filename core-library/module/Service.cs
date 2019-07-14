using System;

namespace Tete.Modules
{

  public class Service
  {

    #region "Public Variables"
    
    public string url;
    public string name;

    #endregion

    #region Constructors
    
    // Empty Constructor
    public Service()
    {
      this.url = string.Empty;
      this.name = string.Empty;
    }

    // Base Constructor
    public Service(string url, string name) {
      this.url = url;
      this.name = name;
    }
    
  }
  #endregion

}