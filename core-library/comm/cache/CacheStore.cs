using System;
using System.Collections;
using System.Collections.Generic;

namespace Tete.Comm.Cache
{

  public class CacheStore : ICacheStore
  {

    #region "Private Variables"

    private static Dictionary<CacheName, object> storage = new Dictionary<CacheName, object>();
    private static Dictionary<CacheName, CacheContract> contracts = new Dictionary<CacheName, CacheContract>();

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
      storage[name] = value;
      contracts[name] = contract;
    }

    public void Save(Tete.Modules.Module module)
    {
      Save(GetObjectName(module), module, new CacheContract());
    }

    #endregion

    public object Retrieve(CacheName name)
    {
      ContractResult result = IsExpired(name);

      Console.WriteLine(name);
      Console.WriteLine(storage.Keys.Count);
      foreach(CacheName key in storage.Keys)
      {
        Console.WriteLine(key);
        Console.WriteLine(storage[key]);
        Console.WriteLine(contracts[key]);
      }

      if(!storage.ContainsKey(name))
      {
        throw new CacheException("Mising Data");
      }

      if (!contracts.ContainsKey(name))
      {
        throw new CacheException("Missing Contract");
      }

      if (result == ContractResult.AbsoluteExpired)
      {
        throw new CacheException("Data beyond absolute life.");
      }

      if (result == ContractResult.Expired)
      {
        throw new CacheException("Data beyond life.");
      }

      return storage[name];
    }

    public List<object> Find(string search)
    {
      List<object> rtnList = new List<object>();

      foreach (CacheName key in storage.Keys)
      {
        if (key.Contains(search) && IsExpired(key) == ContractResult.Accessible)
        {
          rtnList.Add(storage[key]);
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

      CacheName rtnValue = new CacheName(String.Format("Module.{0}", module.Name));
Console.WriteLine(rtnValue.Value);
      return rtnValue;
    }

    #endregion

    #endregion

    #region "Private Functions"

    private ContractResult IsExpired(CacheName name)
    {
      ContractResult rtnResult = ContractResult.Missing;
      DateTime now = DateTime.UtcNow;
      if (contracts.ContainsKey(name) && contracts[name] != null)
      {
        CacheContract contract = contracts[name];
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