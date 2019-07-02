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

      sc.Invoke(sr);
      Assert.Inconclusive();
    }

  }
}