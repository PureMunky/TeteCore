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

    CacheStore cacheStore = new CacheStore();
    private const string TestingFunctionBody = "testing function body";

    [SetUp]
    public void Setup()
    {
      cacheStore.Clear();
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
      ServiceCtrl sc = new ServiceCtrl(mockHttpClient, this.cacheStore);

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

      sc.RegisterService(new HttpService("Test", "GetHello"));

      sc.Invoke(sr);
      ServiceResponse sRes = sc.Invoke(sr);

      Assert.IsTrue(sRes.FromCache);
    }

    [Test]
    public void InvokeFunction()
    {
      FunctionService fr = new FunctionService("Test", "GetHello", TestFunction);
      ServiceCtrl sc = new ServiceCtrl();
      ServiceRequest sr = new ServiceRequest("Test", "GetHello");

      sc.RegisterService(fr);
      ServiceResponse sRes = sc.Invoke(sr);

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