using NUnit.Framework;
using Tete.Comm.Service;

namespace Tete.Comm.Service
{
  public class ServiceRequstTests
  {
    [Test]
    public void EmptyConstructor()
    {
      ServiceRequest sr = new ServiceRequest();

      Assert.IsEmpty(sr.Module);
      Assert.IsEmpty(sr.Service);
    }
  }
}