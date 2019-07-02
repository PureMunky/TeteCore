using System;

namespace Comm.Cache
{

  public class CacheContract
  {

    #region "Public Variables"

    public TimeSpan Life;
    public TimeSpan AbsoluteLife;
    public readonly DateTime LastAccessed;
    public readonly DateTime Created;

    #endregion

    #region Constructors

    // Empty Constructor
    public CacheContract()
    {
      this.Life = new TimeSpan(0);
      this.AbsoluteLife = new TimeSpan(0);
      this.LastAccessed = DateTime.UtcNow;
      this.Created = DateTime.UtcNow;
    }

    // Base Constructor
    public CacheContract(TimeSpan life, TimeSpan absoluteLife)
    {
      this.Life = life;
      this.AbsoluteLife = absoluteLife;
      this.LastAccessed = DateTime.UtcNow;
      this.Created = DateTime.UtcNow;
    }

    #endregion

  }
}