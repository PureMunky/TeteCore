using System;

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
  }
}