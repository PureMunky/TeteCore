using System;
using System.ComponentModel.DataAnnotations;

namespace Tete.Models.Voting
{
  public class Vote
  {
    public Guid VoteId { get; set; }

    public Guid TopicId { get; set; }

    public bool Active { get; set; }

    public string Description { get; set; }
    public string Link { get; set; }

    public DateTime Created { get; set; }
    public DateTime CloseDate { get; set; }

    public Vote()
    {
      this.VoteId = Guid.NewGuid();
      this.Active = true;
      this.Created = DateTime.UtcNow;
      this.TopicId = Guid.Empty;
      this.Description = "";
      this.Link = "";
    }
  }
}