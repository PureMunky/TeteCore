using System;
using System.ComponentModel.DataAnnotations;

namespace Tete.Models.Voting
{
  public class TopicChange
  {

    public Guid TopicChangeId { get; set; }

    public Guid VoteId { get; set; }
    public Vote Vote { get; set; }

    public Guid TopicId { get; set; }
    public string NewName { get; set; }
    public string NewDescription { get; set; }

    public TopicChange()
    {

    }

    public TopicChange(Guid topicId, Guid voteId, string newName, string newDescription)
    {
      this.TopicChangeId = Guid.NewGuid();
      this.VoteId = voteId;
      this.TopicId = topicId;
      this.NewName = newName;
      this.NewDescription = newDescription;
    }
  }
}