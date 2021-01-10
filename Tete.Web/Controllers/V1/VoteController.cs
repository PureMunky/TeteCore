using Microsoft.AspNetCore.Mvc;
using Tete.Models.Voting;
using Tete.Web.Models;
using System;

namespace Tete.Api.Controllers
{
  [Route("V1/[controller]/[action]")]
  [ApiController]
  public class VoteController : ControllerRoot
  {

    // TODO: update to current controller structure.

    public VoteController(Contexts.MainContext mainContext) : base(mainContext)
    {
    }

    // GET api/values
    [HttpGet]
    public Response<VoteVM> GetTopicVotes(Guid topicId)
    {
      var service = new Services.Voting.VoteService(Context, CurrentUser);

      return new Response<VoteVM>(service.GetTopicVotes(topicId));
    }

  }
}