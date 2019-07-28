namespace Tete.Comm.Cache
{

  public class CacheName
  {
    private string value;

    public CacheName(string value)
    {
      this.value = value;
    }

    public bool Contains(string value)
    {
      return this.value.Contains(value);
    }

    public override string ToString()
    {
      return value;
    }
  }

}