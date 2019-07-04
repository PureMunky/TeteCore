using NUnit.Framework;
using Comm.Service;

namespace Tests.Comm.Service
{
  public class ServiceCtrlTests
  {

    [Test]
    public void EmptyConstructor()
    {
      ServiceCtrl sc = new ServiceCtrl();
      Assert.Pass();
    }

    [Test]
    public void Invoke()
    {
      ServiceRequest sr = new ServiceRequest("Test", "GetHello");
      ServiceCtrl sc = new ServiceCtrl();

      ServiceResponse sRes = sc.Invoke(sr);

      Assert.AreEqual(sr.Method, sRes.Request.Method);
      Assert.AreEqual(sr.Module, sRes.Request.Module);
      Assert.AreEqual(sr.Service, sRes.Request.Service);
      Assert.IsFalse(sRes.FromCache);
    }

    [Test]
    public void InvokeFromCache()
    {
      ServiceRequest sr = new ServiceRequest("Test", "GetHello");
      ServiceCtrl sc = new ServiceCtrl();

      sc.Invoke(sr);
      ServiceResponse sRes = sc.Invoke(sr);

      Assert.IsTrue(sRes.FromCache);
    }

  }
}