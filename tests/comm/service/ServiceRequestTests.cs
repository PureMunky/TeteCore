using NUnit.Framework;
using Tete.Comm.Service;

namespace Tests.Comm.Service
{
  public class ServiceRequestTests
  {

    [Test]
    public void EmptyConstructor()
    {
      string test = "Empty Constructor: ";

      ServiceRequest sr = new ServiceRequest();

      Assert.AreEqual(string.Empty, sr.Module, test + "Module should be empty.");
      Assert.AreEqual(string.Empty, sr.Service, test + "Service should be empty.");
    }

    [Test]
    public void BaseConstructor()
    {
      string test = "Base Constructor: ";

      string module = "hello";
      string service = "getHello";

      ServiceRequest sr = new ServiceRequest(module, service);

      Assert.AreEqual(module, sr.Module, test + "Module should have a value.");
      Assert.AreEqual(service, sr.Service, test + "Service should have a value.");
    }

  }
}