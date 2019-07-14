using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tete.Comm.Service;

namespace core.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ModuleController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<ServiceResponse> Get()
    {
      ServiceCtrl sc = new ServiceCtrl();

      return sc.Invoke(new ServiceRequest("Modules", "GetAll")).Result;
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
