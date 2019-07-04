using System;
using System.Collections;

namespace Comm.Cache
{

  public static class CacheStore
  {

    #region "Private Variables"

    private static Hashtable storage = new Hashtable();
    
    #endregion

    #region "Public Functions"

    public static void Clear()
    {
      storage.Clear();
    }

    public static void Save(string name, object value)
    {
      storage[name] = value;
    }

    public static object Retrieve(string name)
    {
      return storage[name];
    }

    public static int Count()
    {
      return storage.Count;
    }

    #endregion
  }

}