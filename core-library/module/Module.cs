using System;
using System.Collections;

namespace Tete.Modules
{
  public class Module
  {
    #region "Public Properties"
    /// <summary>
    /// The Unique Name of the module.
    /// Used to identify the module for calls.
    /// </summary>
    /// <value></value>
    public string Name { get; set; }

    /// <summary>
    /// The url that all of the available services are appended to.
    /// </summary>
    /// <value></value>
    public string BaseUrl { get; set; }

    public Hashtable Services { get; }

    #endregion

    #region Constructors

    public Module()
    {
      this.Name = String.Empty;
      this.BaseUrl = String.Empty;
      this.Services = new Hashtable();
    }

    public Module(string name, string baseUrl)
    {
      this.Name = name;
      this.BaseUrl = baseUrl;
      this.Services = new Hashtable();
    }

    #endregion

    #region "Public Functions"

    public void AddService(Service service)
    {
      this.Services[service.name] = service;
    }

    #endregion
  }
}
