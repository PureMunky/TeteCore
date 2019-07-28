using NUnit.Framework;
using Tete.Modules;
using Moq;

namespace Tests.Modules
{
  public class ModuleServiceTests
  {
    [SetUp]
    

    [Test]
    public void GetsModules()
    {
      var mockCacheStore = new Mock<Tete.Comm.Cache.ICacheStore>();
      mockCacheStore.Setup(x => x.Retrieve(new Tete.Comm.Cache.CacheName(""))).Returns(new object() {});
      ModuleService ms = new ModuleService(mockCacheStore.Object);
      Assert.Inconclusive();

    }
  }
}