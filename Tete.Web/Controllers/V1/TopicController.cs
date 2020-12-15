using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Tete.Models.Content;
using Tete.Models.Relationships;
using Tete.Web.Models;

namespace Tete.Api.Controllers
{
  [Route("V1/[controller]/[action]")]
  [ApiController]
  public class TopicController : ControllerRoot
  {


    public TopicController(Contexts.MainContext mainContext) : base(mainContext)
    {
    }

    [HttpPost]
    public Response<TopicVM> Post([FromBody] TopicVM value)
    {
      var service = new Services.Content.TopicService(Context, CurrentUser);

      LogService.Write("Saved Topic", value.TopicId.ToString());

      return new Response<TopicVM>(service.SaveTopic(value));
    }

    [HttpPost]
    public Response<bool> RegisterLearner(Guid UserId, Guid TopicId)
    {
      var service = new Services.Relationships.MentorshipService(Context, CurrentUser);
      service.RegisterLearner(UserId, TopicId);

      LogService.Write("Registered as Learner", String.Format("User:{0};Topic:{1}", UserId.ToString(), TopicId.ToString()));

      return new Response<bool>(true);
    }

    [HttpPost]
    public Response<bool> RegisterMentor(Guid UserId, Guid TopicId)
    {
      var service = new Services.Relationships.MentorshipService(Context, CurrentUser);
      service.RegisterMentor(UserId, TopicId);

      LogService.Write("Registered as Mentor", String.Format("User:{0};Topic:{1}", UserId.ToString(), TopicId.ToString()));

      return new Response<bool>(true);
    }

    [HttpPost]
    public Response<bool> RequestAssessment(Guid UserId, Guid TopicId)
    {
      var service = new Services.Relationships.AssessmentService(Context, CurrentUser);
      service.CreateAssessment(UserId, TopicId);

      LogService.Write("Requested an Assessment", String.Format("User:{0};Topic:{1}", UserId.ToString(), TopicId.ToString()));

      return new Response<bool>(true);
    }

    [HttpPost]
    public Response<MentorshipVM> ClaimNextMentorship(Guid UserId, Guid TopicId)
    {
      var service = new Services.Relationships.MentorshipService(Context, CurrentUser);

      LogService.Write("Claim next mentorship", String.Format("User:{0};Topic:{1}", UserId.ToString(), TopicId.ToString()));

      return new Response<MentorshipVM>(service.ClaimNextMentorship(UserId, TopicId));
    }

    [HttpGet]
    public Response<TopicVM> Search(string searchText)
    {
      var service = new Services.Content.TopicService(Context, CurrentUser);

      return new Response<TopicVM>(service.Search(searchText));
    }

    [HttpGet]
    public Response<TopicVM> GetTopic(Guid topicId)
    {
      var service = new Services.Content.TopicService(Context, CurrentUser);

      return new Response<TopicVM>(service.GetTopicVM(topicId));
    }

    [HttpGet]
    public Response<TopicVM> GetTopTopics()
    {
      var service = new Services.Content.TopicService(Context, CurrentUser);

      return new Response<TopicVM>(service.GetTopTopics());
    }

    [HttpGet]
    public Response<TopicVM> GetNewestTopics()
    {
      var service = new Services.Content.TopicService(Context, CurrentUser);

      return new Response<TopicVM>(service.GetNewestTopics());
    }

    [HttpGet]
    public Response<TopicVM> GetWaitingTopics()
    {
      var service = new Services.Content.TopicService(Context, CurrentUser);

      return new Response<TopicVM>(service.GetWaitingTopics());
    }

    [HttpGet]
    public Response<TopicVM> GetUserTopics(Guid userId)
    {
      var service = new Services.Content.TopicService(Context, CurrentUser);

      return new Response<TopicVM>(service.GetUsersTopics(userId));
    }

    [HttpGet]
    public Response<TopicVM> GetKeywordTopics(string keyword)
    {
      var service = new Services.Content.TopicService(Context, CurrentUser);

      return new Response<TopicVM>(service.GetKeywordTopics(keyword));
    }

  }
}