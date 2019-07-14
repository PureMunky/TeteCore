using System;
using System.Collections;

namespace Tete.Comm.Cache
{

  public static class CacheStore
  {

    #region "Private Variables"

    private static Hashtable storage = new Hashtable();
    private static Hashtable contracts = new Hashtable();

    #endregion

    #region "Public Functions"

    public static void Clear()
    {
      storage.Clear();
    }

    #region Save

    /// <summary>
    /// Save an object to the cache store using the default contract.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public static void Save(string name, object value)
    {
      Save(name, value, new CacheContract());
    }

    /// <summary>
    /// Save an object to the cache store using the passed in contract.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="contract"></param>
    public static void Save(string name, object value, CacheContract contract)
    {
      storage[name] = value;
      contracts[name] = contract;
    }

    #endregion

    public static object Retrieve(string name)
    {
      CacheContract contract = (CacheContract)contracts[name];
      DateTime now = DateTime.UtcNow;

      if (contracts[name] == null || storage[name] == null)
      {
        throw new CacheException("Missing Data");
      }

      if (now.Subtract(contract.Created) >= contract.AbsoluteLife)
      {
        throw new CacheException("Data beyond absolute life.");
      }

      if (now.Subtract(contract.LastAccessed) >= contract.Life)
      {
        throw new CacheException("Data beyond life.");
      }

      return storage[name];
    }

    public static int Count()
    {
      return storage.Count;
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