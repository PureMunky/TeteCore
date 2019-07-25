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
    public void Save(string name, object value)
    {
      Save(name, value, new CacheContract());
    }

    /// <summary>
    /// Save an object to the cache store using the passed in contract.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="contract"></param>
    public void Save(string name, object value, CacheContract contract)
    {
      storage[name] = value;
      contracts[name] = contract;
    }

    #endregion

    public object Retrieve(string name)
    {
      ContractResult result = IsExpired(name);

      if (contracts[name] == null || storage[name] == null)
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

      return storage[name];
    }

    public List<object> Find(string search)
    {
      List<object> rtnList = new List<object>();

      foreach (string key in storage.Keys)
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

    #endregion

    #region "Private Functions"

    private ContractResult IsExpired(string name)
    {
      ContractResult rtnResult = ContractResult.Missing;
      CacheContract contract = (CacheContract)contracts[name];
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