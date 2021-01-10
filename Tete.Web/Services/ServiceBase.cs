using Tete.Api.Contexts;
using Tete.Models.Authentication;

namespace Tete.Api.Services
{
  public abstract class ServiceBase
  {
    protected MainContext mainContext;

    protected UserVM Actor;

    protected Logging.LogService LogService
    {
      get
      {
        return new Logging.LogService(this.mainContext, Tete.Api.Services.Logging.LogService.LoggingLayer.Service, this.Actor);
      }
    }

    protected Content.TopicService TopicService
    {
      get
      {
        return new Content.TopicService(this.mainContext, this.Actor);
      }
    }

    protected Relationships.MentorshipService MentorshipService
    {
      get
      {
        return new Relationships.MentorshipService(this.mainContext, this.Actor);
      }
    }

    protected Localization.UserLanguageService UserLanguageService
    {
      get
      {
        return new Localization.UserLanguageService(this.mainContext, this.Actor);
      }
    }

    protected Relationships.AssessmentService AssessmentService
    {
      get
      {
        return new Relationships.AssessmentService(this.mainContext, this.Actor);
      }
    }

    protected Voting.VoteService VoteService
    {
      get
      {
        return new Voting.VoteService(this.mainContext, this.Actor);
      }
    }

    protected Users.UserService UserService
    {
      get
      {
        return new Users.UserService(this.mainContext, this.Actor);
      }
    }
  }
}