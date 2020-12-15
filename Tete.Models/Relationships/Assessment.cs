using Microsoft.EntityFrameworkCore.Design;
using System;
using System.ComponentModel.DataAnnotations;
using Tete.Models.Content;
using Tete.Models.Authentication;

namespace Tete.Models.Relationships
{

  public class Assessment
  {
    [Required]
    public Guid AssessmentId { get; set; }

    [Required]
    public Guid TopicId { get; set; }
    public Topic Topic { get; set; }

    [Required]
    public bool Active { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    // If the assessment was created from a mentorship this will be populated.
    // A cold assessment request will have no mentorship id.
    public Guid MentorshipId { get; set; }

    [Required]
    public Guid LearnerUserId { get; set; }
    public User LearnerUser { get; set; }
    public string LearnerDetails { get; set; }

    // An assessment without and AssessorUserId is a request for an assessment.
    public Guid AssessorUserId { get; set; }
    public User AssessorUser { get; set; }
    public string AssessorDetails { get; set; }

    // Public comments about the assessment results.
    // Feedback to the learner and future assessors.
    public string AssessorComments { get; set; }

    // True = Passed
    // False = Failed
    public bool AssessmentResult { get; set; }

    public double Score { get; set; }

    public DateTime AssignedDate { get; set; }
    public DateTime CompletedDate { get; set; }

    public Assessment()
    {

    }

    public Assessment(Guid LearnerUserId, Guid TopicId, Guid MentorshipId)
    {
      this.AssessmentId = Guid.NewGuid();
      this.LearnerUserId = LearnerUserId;
      this.AssessorUserId = Guid.Empty;
      this.TopicId = TopicId;
      this.MentorshipId = MentorshipId;
      this.Active = true;
      this.CreatedDate = DateTime.UtcNow;
    }
  }
}