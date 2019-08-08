using System.Collections.Generic;

namespace Tete.Comm.Cache
{
  public interface ICacheStore
  {
    void Clear();
    void Save(CacheName name, object value);
    void Save(CacheName name, object value, CacheContract contract);
    void Save(Tete.Modules.Module module);

    CacheName GetObjectName(Tete.Modules.Module module);

    object Retrieve(CacheName name);
    int Count();
    List<object> Find(string search);
  }
}