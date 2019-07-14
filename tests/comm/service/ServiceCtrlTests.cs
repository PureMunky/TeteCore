using NUnit.Framework;
using Tete.Comm.Service;
using Tete.Comm.Cache;
using System.Threading.Tasks;
using System.Net.Http;
using Moq;

namespace Tests.Comm.Service
{
  public class ServiceCtrlTests
  {

    private const string TestingFunctionBody = "testing function body";

    [SetUp]
    public void Setup()
    {
      CacheStore.Clear();
    }

    [Test]
    public void EmptyConstructor()
    {
      ServiceCtrl sc = new ServiceCtrl();
      Assert.Pass();
    }

    [Test]
    public void InvokeHttp()
    {
      string expected = "tests";
      var mockHttpClient = new HttpClientService(expected);

      ServiceRequest sr = new ServiceRequest("Test", "GetHello");
      ServiceCtrl sc = new ServiceCtrl(mockHttpClient);

      sc.RegisterService(new HttpService("Test", "GetHello"));

      ServiceResponse sRes = sc.Invoke(sr);

      Assert.AreEqual(sr.Module, sRes.Request.Module);
      Assert.AreEqual(sr.Service, sRes.Request.Service);
      Assert.IsFalse(sRes.FromCache);
      Assert.AreEqual(expected, sRes.Body);
    }

    [Test]
    public void InvokeHttpFromCache()
    {
      ServiceRequest sr = new ServiceRequest("Test", "GetHello");
      ServiceCtrl sc = new ServiceCtrl();

      sc.Invoke(sr);
      ServiceResponse sRes = sc.Invoke(sr);

      Assert.IsTrue(sRes.FromCache);
    }

    [Test]
    public void InvokeFunction()
    {
      FunctionService fr = new FunctionService("Test", "GetHello", TestFunction);
      ServiceCtrl sc = new ServiceCtrl();

      ServiceResponse sRes = sc.Invoke(fr);

      Assert.AreEqual(fr.Module, sRes.Request.Module);
      Assert.AreEqual(fr.Service, sRes.Request.Service);
      Assert.IsFalse(sRes.FromCache);
      Assert.AreEqual(TestingFunctionBody, sRes.Body);
    }

    private ServiceResponse TestFunction(ServiceRequest request)
    {
      return new ServiceResponse(request)
      {
        Body = TestingFunctionBody
      };
    }
  }
}