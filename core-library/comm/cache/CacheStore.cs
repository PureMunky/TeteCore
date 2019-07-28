using System;
using System.Collections;
using System.Collections.Generic;

namespace Tete.Comm.Cache
{

  public class CacheStore : ICacheStore
  {

    #region "Private Variables"

    private static Hashtable storage = new Hashtable();
    private static Hashtable contracts = new Hashtable();

    #endregion

    #region "Public Properties"

    public enum ContractResult
    {
      Accessible = 0,
      AbsoluteExpired = 1,
      Expired = 2,
      Missing = 3
    }

    #endregion

    #region "Public Functions"

    public void Clear()
    {
      storage.Clear();
    }

    #region Save

    /// <summary>
    /// Save an object to the cache store using the default contract.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public void Save(CacheName name, object value)
    {
      Save(name, value, new CacheContract());
    }

    /// <summary>
    /// Save an object to the cache store using the passed in contract.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="contract"></param>
    public void Save(CacheName name, object value, CacheContract contract)
    {
      storage[name.ToString()] = value;
      contracts[name.ToString()] = contract;
    }

    public void Save(Tete.Modules.Module module)
    {
      Save(GetObjectName(module), module, new CacheContract());
    }

    #endregion

    public object Retrieve(CacheName name)
    {
      ContractResult result = IsExpired(name.ToString());

      if (contracts[name.ToString()] == null || storage[name.ToString()] == null)
      {
        throw new CacheException("Missing Data");
      }

      if (result == ContractResult.AbsoluteExpired)
      {
        throw new CacheException("Data beyond absolute life.");
      }

      if (result == ContractResult.Expired)
      {
        throw new CacheException("Data beyond life.");
      }

      return storage[name.ToString()];
    }

    public List<object> Find(string search)
    {
      List<object> rtnList = new List<object>();

      foreach (string key in storage.Keys)
      {
        if (key.Contains(search) && IsExpired(key) == ContractResult.Accessible)
        {
          rtnList.Add(storage[key.ToString()]);
        }
      }

      return rtnList;
    }

    public int Count()
    {
      return storage.Count;
    }

    #region "GetObjectName"

    public CacheName GetObjectName(Tete.Modules.Module module)
    {
      return new CacheName(String.Format("Module.{0}", module.Name));
    }

    #endregion

    #endregion

    #region "Private Functions"

    private ContractResult IsExpired(string name)
    {
      ContractResult rtnResult = ContractResult.Missing;
      CacheContract contract = (CacheContract)contracts[name.ToString()];
      DateTime now = DateTime.UtcNow;
      if (contract != null)
      {
        rtnResult = ContractResult.Accessible;
        if (now.Subtract(contract.Created) >= contract.AbsoluteLife)
        {
          rtnResult = ContractResult.AbsoluteExpired;
        }
        else if (now.Subtract(contract.LastAccessed) >= contract.Life)
        {
          rtnResult = ContractResult.Expired;
        }
      }

      return rtnResult;
    }

    #endregion
  }

  public class CacheException : Exception
  {

    public CacheException(string message) :
      base(message)
    {

    }
  }
}