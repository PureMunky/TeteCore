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
    // TODO: REbuild this from mentor to assessment.
    // [HttpPost]
    // public Response<AssessmentVM> CreateAssessment([FromBody] AssessmentVM value)
    // {
    //   var service = new Services.Relationships.AssessmentService(Context, CurrentUser);
    //   service.CreateAssessment(value.LearnerUserId, value.TopicId);

    //   return new Response<AssessmentVM>(value);
    // }

    [HttpGet]
    public Response<AssessmentVM> GetAssessment(Guid AssessmentId)
    {
      var service = new Services.Relationships.AssessmentService(Context, CurrentUser);

      return new Response<AssessmentVM>(service.GetAssessment(AssessmentId));
    }

    [HttpGet]
    public Response<MentorshipVM> GetMentorship(Guid MentorshipId)
    {
      var service = new Services.Relationships.MentorshipService(Context, CurrentUser);

      return new Response<MentorshipVM>(service.GetMentorship(MentorshipId));
    }

    [HttpPost]
    public Response<MentorshipVM> SetContactDetails([FromBody] ContactUpdate ContactUpdate)
    {
      var service = new Services.Relationships.MentorshipService(Context, CurrentUser);

      LogService.Write("Save Contact Details", String.Format("User:{0};Mentorship:{1}", ContactUpdate.UserId, ContactUpdate.MentorshipId));
      return new Response<MentorshipVM>(service.SetContactDetails(ContactUpdate));
    }

    [HttpPost]
    public Response<MentorshipVM> CloseMentorship([FromBody] Evaluation evaluation)
    {
      var service = new Services.Relationships.MentorshipService(Context, CurrentUser);

      LogService.Write("Close Mentorship", String.Format("User:{0};Mentorship:{1}", evaluation.UserId, evaluation.MentorshipId));

      return new Response<MentorshipVM>(service.CloseMentorship(evaluation));
    }

    [HttpPost]
    public Response<MentorshipVM> CancelMentorship(Guid MentorshipId)
    {
      var service = new Services.Relationships.MentorshipService(Context, CurrentUser);

      LogService.Write("Cancel Mentorship", String.Format("User:{0};Mentorship:{1}", CurrentUser.UserId, MentorshipId));

      return new Response<MentorshipVM>(service.CancelMentorship(MentorshipId));
    }

  }
}