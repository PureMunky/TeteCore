using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tete.Modules;

namespace Tete.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ModuleController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<List<Module>> Get()
    {
      ModuleService ms = new ModuleService();

      return ms.GetAll();
    }

    // GET api/values/Example
    [HttpGet("{name}")]
    public ActionResult<Module> Get(string name)
    {
      ModuleService ms = new ModuleService();

      return ms.Get(name);
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] Module module)
    {
      new ModuleService().Create(module);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put([FromBody] Module module)
    {
      new ModuleService().Save(module);
    }

    // DELETE api/values/Example
    [HttpDelete("{name}")]
    public void Delete(string name)
    {
      new ModuleService().Delete(name);
    }
  }
}
