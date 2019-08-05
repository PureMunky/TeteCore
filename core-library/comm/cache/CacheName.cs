using System;

namespace Tete.Comm.Cache
{

  public class CacheName : System.IEquatable<CacheName>
  {
    public readonly string Value;
    public readonly string Module;

    public CacheName(string value)
    {
      string[] parts = value.Split('.');
      if(parts.Length < 2) throw new CacheException("CacheName doesn't match the required format.");
      this.Module = parts[0];
      this.Value = value;
    }

    public bool Equals(CacheName compare)
    {
      return (this.Value == compare.Value);
    }

    public bool Contains(string value)
    {
      return this.Value.Contains(value);
    }

    public override string ToString()
    {
      return Value;
    }
  }

}