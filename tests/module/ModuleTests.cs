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
    }
  }
}