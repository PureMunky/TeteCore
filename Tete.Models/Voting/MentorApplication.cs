using System;
using System.ComponentModel.DataAnnotations;

namespace Tete.Models.Voting
{
  public class MentorApplication
  {
    public Guid MentorApplicationId { get; set; }

    public Guid VoteId { get; set; }
    public Vote Vote { get; set; }

    public Guid TopicId { get; set; }
    public Tete.Models.Content.Topic Topic { get; set; }

    public Guid UserId { get; set; }
    public Tete.Models.Authentication.User User { get; set; }

    public MentorApplication()
    {

    }

    public MentorApplication(Guid voteId, Guid userId, Guid topicId)
    {
      this.MentorApplicationId = Guid.NewGuid();
      this.VoteId = voteId;
      this.TopicId = topicId;
      this.UserId = userId;
    }
  }
}