using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Tete.Modules
{

  public class ModuleService : DbContext
  {

    #region "Private Variables"

    private readonly Comm.Cache.ICacheStore cacheStore;

    #endregion

    public DbSet<Module> Modules {get;set;}

    #region Constructors

public ModuleService()
{
  this.cacheStore = new Tete.Comm.Cache.CacheStore();
}

    public ModuleService(DbContextOptions<ModuleService> options) : base(options)
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

      foreach(object o in this.cacheStore.Find("Module."))
      {
        rtnList.Add(o as Module);
      }

      return rtnList;
    }

    public Module Get(string name)
    {
      return this.cacheStore.Retrieve(new Comm.Cache.CacheName(String.Format("Module.{0}", name))) as Module;
    }

    public void Create(Module module)
    {

    }

    public void Save(Module module)
    {
        this.cacheStore.Save(module);
    }

    public void Delete(string name)
    {
      
    }

    #endregion
  }
}