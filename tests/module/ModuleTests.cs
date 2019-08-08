using NUnit.Framework;
using Tete.Modules;

namespace Tests.Modules
{
  public class ModuleTests
  {
    [Test]
    public void EmptyConstructor()
    {
      Module m = new Module();

      Assert.IsEmpty(m.Name);
      Assert.IsEmpty(m.BaseUrl);
      Assert.AreEqual(0, m.Services.Count);
    }

    [Test]
    public void BaseConstructor()
    {
      string name = "test";
      string baseUrl = "https://www.google.com";

      Module m = new Module(name, baseUrl);

      Assert.AreEqual(name, m.Name);
      Assert.AreEqual(baseUrl, m.BaseUrl);
      Assert.AreEqual(0, m.Services.Count);
    }

    [Test]
    public void AddsServices()
    {
      string serviceName = "testName";
      string serviceUrl = "testUrl";

      Module m = new Module();

      m.AddService(new Service(serviceUrl, serviceName));

      Assert.AreEqual(1, m.Services.Count);
    }
  }
}