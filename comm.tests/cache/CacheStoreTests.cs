using NUnit.Framework;
using Comm.Cache;

namespace Tests.Comm.Cache
{

  public class CacheStoreTests
  {

    [SetUp]
    public void Setup()
    {
      CacheStore.Clear();
    }

    [Test]
    public void InitialState()
    {
      Assert.AreEqual(0, CacheStore.Count());
    }

    [Test]
    public void StoresValues()
    {
      string name = "test";
      string value = "testValue";

      CacheStore.Save(name, value);

      string actual = (string)CacheStore.Retrieve(name);

      Assert.AreEqual(value, actual);
    }

    [Test]
    public void StoresValueWithExpiredAbsoluteLife()
    {
      string name = "test";
      string value = "testValue";
      CacheContract contract = new CacheContract(new System.TimeSpan(0), new System.TimeSpan(0));

      CacheStore.Save(name, value, contract);

      string actual = "";

      try
      {
        actual = (string)CacheStore.Retrieve(name);
        Assert.Fail();
      }
      catch(CacheException e)
      {
        Assert.Pass(e.Message);
      }
    }

    [Test]
    public void StoresValuesWithExpiredLife()
    {
      string name = "test";
      string value = "testValue";
      CacheContract contract = new CacheContract(new System.TimeSpan(0), new System.TimeSpan(0,30,0));

      CacheStore.Save(name, value, contract);
      
      string actual = "";

      try
      {
        actual = (string)CacheStore.Retrieve(name);
        Assert.Fail();
      }
      catch(CacheException e)
      {
        Assert.Pass(e.Message);
      }
    }

    [Test]
    public void ClearsStorage()
    {
      int start = CacheStore.Count();
      CacheStore.Save("fake", "data");
      int middle = CacheStore.Count();
      CacheStore.Clear();
      int final = CacheStore.Count();

      Assert.AreEqual(0, start);
      Assert.AreEqual(1, middle);
      Assert.AreEqual(0, final);      
    }

  }
}