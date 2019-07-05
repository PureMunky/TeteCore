using NUnit.Framework;
using Comm.Service;

namespace Tests.Comm.Service
{

  public class ServiceResponseTests
  {

    [Test]
    public void BaseConstructor()
    {
      ServiceRequest sReq = new ServiceRequest();
      ServiceResponse sRes = new ServiceResponse(sReq);

      Assert.AreSame(sReq, sRes.Request);
      Assert.IsFalse(sRes.FromCache);
      Assert.AreEqual(string.Empty, sRes.Body);
    }
  }

}