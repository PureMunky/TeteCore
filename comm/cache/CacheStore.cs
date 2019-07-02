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

    public static void Save(string name, string value)
    {
      storage[name] = value;
    }

    #endregion
  }

}