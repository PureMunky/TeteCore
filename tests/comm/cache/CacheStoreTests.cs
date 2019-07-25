using NUnit.Framework;
using Tete.Comm.Cache;
using System.Collections.Generic;

namespace Tests.Comm.Cache
{

  public class CacheStoreTests
  {
    CacheStore cacheStore = new CacheStore();
    [SetUp]
    public void Setup()
    {
      cacheStore.Clear();
    }

    [Test]
    public void InitialState()
    {
      Assert.AreEqual(0, cacheStore.Count());
    }

    [Test]
    public void StoresValues()
    {
      string name = "test";
      string value = "testValue";

      cacheStore.Save(name, value);

      string actual = (string)cacheStore.Retrieve(name);

      Assert.AreEqual(value, actual);
    }

    [Test]
    public void StoresValueWithExpiredAbsoluteLife()
    {
      string name = "test";
      string value = "testValue";
      CacheContract contract = new CacheContract(new System.TimeSpan(0), new System.TimeSpan(0));

      cacheStore.Save(name, value, contract);

      string actual = "";

      try
      {
        actual = (string)cacheStore.Retrieve(name);
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

      cacheStore.Save(name, value, contract);
      
      string actual = "";

      try
      {
        actual = (string)cacheStore.Retrieve(name);
        Assert.Fail();
      }
      catch(CacheException e)
      {
        Assert.Pass(e.Message);
      }
    }

    [Test]
    public void RetrieveMissingValue()
    {
      string name = "test";
      string actual = "";

      try
      {
        actual = (string)cacheStore.Retrieve(name);
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
      int start = cacheStore.Count();
      cacheStore.Save("fake", "data");
      int middle = cacheStore.Count();
      cacheStore.Clear();
      int final = cacheStore.Count();

      Assert.AreEqual(0, start);
      Assert.AreEqual(1, middle);
      Assert.AreEqual(0, final);      
    }

    [Test]
    public void FindTest()
    {
      cacheStore.Save("Test.1", "hello");
      cacheStore.Save("Test.2", "goodbye");
      cacheStore.Save("Something.Else", "it doesn't matter");
      List<object> results = cacheStore.Find("Test.");

      Assert.AreEqual(2, results.Count);

    }
  }
}