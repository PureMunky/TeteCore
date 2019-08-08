using System;
using NUnit.Framework;
using Tete.Comm.Cache;

namespace Tests.Comm.Cache
{

  public class CacheContractTests
  {
    
    [Test]
    public void EmptyConstructor()
    {
      CacheContract cc = new CacheContract();

      Assert.AreEqual(new TimeSpan(0, 30, 0), cc.Life);
      Assert.AreEqual(new TimeSpan(0, 30, 0), cc.AbsoluteLife);
      Assert.GreaterOrEqual(DateTime.UtcNow, cc.LastAccessed);
      Assert.GreaterOrEqual(DateTime.UtcNow, cc.Created);
    }

    [Test]
    public void BaseConstructor()
    {
      TimeSpan life = new TimeSpan(20);
      TimeSpan absoluteLife = new TimeSpan(30);
      CacheContract cc = new CacheContract(life, absoluteLife);

      Assert.AreEqual(life, cc.Life);
      Assert.AreEqual(absoluteLife, cc.AbsoluteLife);
      Assert.GreaterOrEqual(DateTime.UtcNow, cc.LastAccessed);
      Assert.GreaterOrEqual(DateTime.UtcNow, cc.Created);
    }

  }

}