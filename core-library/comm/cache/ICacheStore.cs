using System.Collections.Generic;

namespace Tete.Comm.Cache
{
  public interface ICacheStore
  {
    void Clear();
    void Save(string name, object value);
    void Save(string name, object value, CacheContract contract);
    object Retrieve(string name);
    int Count();
    List<object> Find(string search);
  }
}