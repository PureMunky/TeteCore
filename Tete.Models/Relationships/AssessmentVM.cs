using System;
using Tete.Models.Content;
using Tete.Models.Authentication;

namespace Tete.Models.Relationships
{

  public class AssessmentVM
  {
    public Guid AssessmentId { get; set; }
    public Guid TopicId { get; set; }
    public TopicVM Topic { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid MentorshipId { get; set; }
    public Guid LearnerUserId { get; set; }
    public UserVM Learner { get; set; }
    public string LearnerDetails { get; set; }
    public Guid AssessorUserId { get; set; }
    public UserVM Assessor { get; set; }
    public string AssessorDetails { get; set; }
    public string AssessorComments { get; set; }
    public bool AssessmentResult { get; set; }
    public bool HasAssessor { get; set; }
    public double Score { get; set; }
    public DateTime AssignedDate { get; set; }
    public DateTime CompletedDate { get; set; }

    public AssessmentVM()
    {

    }

    public AssessmentVM(Assessment assessment)
    {
      this.AssessmentId = assessment.AssessmentId;

      this.TopicId = assessment.TopicId;

      this.Active = assessment.Active;

      this.CreatedDate = assessment.CreatedDate;

      this.MentorshipId = assessment.MentorshipId;

      this.LearnerUserId = assessment.LearnerUserId;
      this.LearnerDetails = assessment.LearnerDetails;

      this.AssessorUserId = assessment.AssessorUserId;
      this.AssessorDetails = assessment.AssessorDetails;
      this.AssessorComments = assessment.AssessorComments;

      this.AssessmentResult = assessment.AssessmentResult;
      this.Score = assessment.Score;

      this.CompletedDate = assessment.CompletedDate;
      this.AssignedDate = assessment.AssignedDate;

      this.HasAssessor = (assessment.AssessorUserId != Guid.Empty);

    }
  }
}