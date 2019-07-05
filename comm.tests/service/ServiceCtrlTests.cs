using NUnit.Framework;
using Comm.Service;
using System.Threading.Tasks;
using System.Net.Http;
using Moq;

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
    public async Task Invoke()
    {
      var mockHttpClient = new Mock<HttpClient>();
      var mockTask = new Mock<Task<string>>();
      mockTask.Setup(x => x.Result = "test");
      //http://dontcodetired.com/blog/post/Mocking-in-NET-Core-Tests-with-Moq
      //https://gingter.org/2018/07/26/how-to-mock-httpclient-in-your-net-c-unit-tests/

      mockHttpClient.Setup(x => x.GetStringAsync(It.IsAny<string>())).Returns(mockTask.Object);

      ServiceRequest sr = new ServiceRequest("Test", "GetHello");
      ServiceCtrl sc = new ServiceCtrl();

      ServiceResponse sRes = await sc.Invoke(sr);

      Assert.AreEqual(sr.Method, sRes.Request.Method);
      Assert.AreEqual(sr.Module, sRes.Request.Module);
      Assert.AreEqual(sr.Service, sRes.Request.Service);
      Assert.IsFalse(sRes.FromCache);
      Assert.AreEqual("", sRes.Body);
    }

    [Test]
    public async Task InvokeFromCache()
    {
      ServiceRequest sr = new ServiceRequest("Test", "GetHello");
      ServiceCtrl sc = new ServiceCtrl();

      await sc.Invoke(sr);
      ServiceResponse sRes = await sc.Invoke(sr);

      Assert.IsTrue(sRes.FromCache);
    }

  }
}