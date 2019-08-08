using NUnit.Framework;
using Tete;
using Moq;

namespace Tests.API
{
  public class StartupTests
  {

    [Test]
    public void Startup()
    {
      var mockConfiguration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
      Startup s = new Startup(mockConfiguration.Object);

      Assert.AreSame(mockConfiguration.Object, s.Configuration);

    }
  }
}