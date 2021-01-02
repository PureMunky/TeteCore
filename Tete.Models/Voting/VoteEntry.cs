using System;
using System.ComponentModel.DataAnnotations;

namespace Tete.Models.Voting
{
  public class VoteEntry
  {
    public Guid VoteEntryId { get; set; }

    public Guid VoteId { get; set; }
    public Vote Vote { get; set; }

    public Guid UserId { get; set; }
    public Tete.Models.Authentication.User User { get; set; }

    public bool Submitted { get; set; }
    public bool Result { get; set; }

    public DateTime SubmitDate { get; set; }

    public VoteEntry()
    {
      this.VoteEntryId = Guid.NewGuid();
    }

    public VoteEntry(Guid voteId, Guid userId)
    {
      this.VoteEntryId = Guid.NewGuid();
      this.VoteId = voteId;
      this.UserId = userId;

    }

  }
}