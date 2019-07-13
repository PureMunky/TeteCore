using NUnit.Framework;
using Tete.Comm.Service;

namespace Tests
{
  public class ServiceTests
  {

    [Test]
    public void EmptyConstructor()
    {
      string test = "Empty Constructor: ";

      ServiceModel sm = new ServiceModel();

      Assert.AreEqual(string.Empty, sm.url, test + "Url should be empty.");
      Assert.AreEqual(string.Empty, sm.name, test + "Name should be empty.");
    }

    [Test]
    public void BaseConstructor()
    {
      string test = "Base Constructor: ";

      string url = "hello";
      string name = "hellowtest";

      ServiceModel sm = new ServiceModel(url, name);

      Assert.AreEqual(url, sm.url, test + "Url should have a value.");
      Assert.AreEqual(name, sm.name, test + "Name should have a value.");
    }

  }
}