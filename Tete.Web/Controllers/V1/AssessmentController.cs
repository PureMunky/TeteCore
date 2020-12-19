using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Tete.Models.Relationships;
using Tete.Models.Users;
using Tete.Api.Helpers;
using Tete.Web.Models;

namespace Tete.Api.Controllers
{
  [Route("V1/[controller]/[action]")]
  [ApiController]
  public class AssessmentController : ControllerRoot
  {


    public AssessmentController(Contexts.MainContext mainContext) : base(mainContext)
    {
    }

    [HttpGet]
    public Response<AssessmentVM> GetAssessment(Guid AssessmentId)
    {
      var service = new Services.Relationships.AssessmentService(Context, CurrentUser);

      return new Response<AssessmentVM>(service.GetAssessment(AssessmentId));
    }

    [HttpGet]
    public Response<AssessmentVM> GetUserAssessments(Guid UserId)
    {
      var service = new Services.Relationships.AssessmentService(Context, CurrentUser);

      return new Response<AssessmentVM>(service.GetUserAssessments(UserId));
    }

  }
}