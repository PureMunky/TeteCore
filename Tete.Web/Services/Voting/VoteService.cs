using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tete.Api.Contexts;
using Tete.Models.Authentication;
using Tete.Models.Voting;
using Tete.Models.Users;

namespace Tete.Api.Services.Voting
{
  public class VoteService : ServiceBase
  {

    #region Public Functions

    public VoteService(MainContext mainContext, UserVM actor)
    {
      this.mainContext = mainContext;
      this.Actor = actor;
    }


    // TODO: Test vote creation.
    public void CreateMentorApplication(Guid userId, Guid topicId)
    {
      var votes = this.mainContext.VoteMentorApplications.Where(v => v.TopicId == topicId && v.UserId == userId && v.Vote.Active).AsNoTracking().ToList();

      if (votes.Count() == 0)
      {
        Vote newVote = new Vote()
        {
          TopicId = topicId
        };
        MentorApplication newApplication = new MentorApplication(newVote.VoteId, userId, topicId);

        var entries = this.mainContext.UserTopics
          .Where(ut => ut.TopicId == topicId && ut.Status >= Models.Relationships.TopicStatus.Mentor)
          .Select(ut => new VoteEntry(newVote.VoteId, ut.UserId)).ToList();

        this.mainContext.Votes.Add(newVote);
        this.mainContext.VoteMentorApplications.Add(newApplication);
        this.mainContext.VoteEntries.AddRange(entries);
        this.mainContext.SaveChanges();
      }
    }

    #endregion
  }
}