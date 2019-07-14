using NUnit.Framework;
using Tete.Modules;

namespace Tests.Modules
{
  public class ServiceTests
  {

    [Test]
    public void EmptyConstructor()
    {
      string test = "Empty Constructor: ";

      Service sm = new Service();

      Assert.AreEqual(string.Empty, sm.url, test + "Url should be empty.");
      Assert.AreEqual(string.Empty, sm.name, test + "Name should be empty.");
    }

    [Test]
    public void BaseConstructor()
    {
      string test = "Base Constructor: ";

      string url = "hello";
      string name = "hellowtest";

      Service sm = new Service(url, name);

      Assert.AreEqual(url, sm.url, test + "Url should have a value.");
      Assert.AreEqual(name, sm.name, test + "Name should have a value.");
    }

  }
}