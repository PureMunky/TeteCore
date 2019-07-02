using NUnit.Framework;
using Comm.Service;

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

  }
}