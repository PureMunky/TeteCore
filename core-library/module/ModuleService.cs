using System;
using System.Collections.Generic;

namespace Tete.Modules
{

  public class ModuleService
  {

    #region "Private Variables"

    private readonly Comm.Cache.ICacheStore cacheStore;

    #endregion

    #region Constructors

    public ModuleService()
    {
      this.cacheStore = new Tete.Comm.Cache.CacheStore();
    }

    public ModuleService(Comm.Cache.ICacheStore cacheStore)
    {
      this.cacheStore = cacheStore;
    }

    #endregion
    
    #region "Public Functions"
    
    public Module GetNew()
    {
      return new Module();
    }

    public List<Module> GetAll()
    {
      List<Module> rtnList = new List<Module>();

      return rtnList;
    }

    public void Save(Module module)
    {

    }

    public void Delete(Module module)
    {
      
    }

    #endregion
  }
}