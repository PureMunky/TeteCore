using System;
using System.ComponentModel.DataAnnotations;

namespace Tete.Models.Voting
{
  public class VoteVM
  {
    public Guid VoteId { get; set; }

    public Guid TopicId { get; set; }

    public bool Active { get; set; }

    public string Description { get; set; }
    public string Link { get; set; }

    public DateTime Created { get; set; }
    public DateTime CloseDate { get; set; }

    public VoteEntry UserEntry { get; set; }

    public VoteVM()
    {
      this.VoteId = Guid.NewGuid();
      this.Active = true;
      this.Created = DateTime.UtcNow;
      this.TopicId = Guid.Empty;
      this.Description = "";
      this.Link = "";
    }

    public VoteVM(Vote vote, VoteEntry userEntry)
    {
      this.VoteId = vote.VoteId;
      this.Active = vote.Active;
      this.Created = vote.Created;
      this.TopicId = vote.TopicId;
      this.Description = vote.Description;
      this.Link = vote.Link;
      this.UserEntry = userEntry;
    }
  }
}