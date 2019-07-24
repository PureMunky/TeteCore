using NUnit.Framework;
using Tete.Controllers;
using Tete.Comm.Service;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controllers
{
  public class ModuleControllerTests
  {

    [Test]
    public void GetAll()
    {
      ModuleController mc = new ModuleController();

      ActionResult<ServiceResponse> sr = mc.Get();

      Assert.AreEqual("Modules", sr.Value.Request.Module);
      Assert.AreEqual("GetAll", sr.Value.Request.Service);
      Assert.IsFalse(sr.Value.FromCache);
    }

    [Test]
    public void GetOne()
    {
      ModuleController mc = new ModuleController();
      ActionResult<string> response = mc.Get(1);

      Assert.AreEqual("value", response.Value);
    }

    [Test]
    public void PostTest()
    {
      ModuleController mc = new ModuleController();
      mc.Post("test");
    }

    [Test]
    public void PutTest()
    {
      ModuleController mc = new ModuleController();
      mc.Put(1, "test");
    }

    [Test]
    public void DeleteTest()
    {
      ModuleController mc = new ModuleController();
      mc.Delete(1);
    }
  }
}