using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tete.Api.Contexts;
using Tete.Models.Relationships;
using Tete.Models.Authentication;
using Tete.Models.Content;
using Tete.Models.Users;

namespace Tete.Api.Services.Relationships
{
  public class AssessmentService : ServiceBase
  {

    #region Public Functions

    public AssessmentService(MainContext mainContext, UserVM actor)
    {
      this.mainContext = mainContext;
      this.Actor = actor;
    }

    // TODO: Test the mentorship association.
    public void CreateAssessment(Guid UserId, Guid TopicId)
    {
      if (UserId == this.Actor.UserId || this.Actor.Roles.Contains("Admin"))
      {
        var dbAssessment = this.mainContext.Assessments.AsNoTracking().Where(a => a.LearnerUserId == UserId && a.TopicId == TopicId && a.Active).FirstOrDefault();

        if (dbAssessment == null)
        {
          var dbMentorship = this.mainContext.Mentorships.AsNoTracking().Where(m => m.TopicId == TopicId && m.LearnerUserId == UserId && m.MentorUserId != Guid.Empty).OrderByDescending(m => m.CreatedDate).FirstOrDefault();
          Guid MentorshipId = Guid.Empty;
          bool go = (dbMentorship == null || (dbMentorship != null && !dbMentorship.Active));

          if (go)
          {
            if (dbMentorship != null && !dbMentorship.Active)
            {
              MentorshipId = dbAssessment.MentorshipId;
            }

            var newAssessment = new Assessment(UserId, TopicId, MentorshipId);
            this.mainContext.Assessments.Add(newAssessment);
            this.mainContext.SaveChanges();
          }
        }
      }
    }

    public AssessmentVM GetAssessment(Guid AssessmentId)
    {
      var dbAssessment = this.mainContext.Assessments.AsNoTracking().Where(a => a.AssessmentId == AssessmentId).FirstOrDefault();
      AssessmentVM rtnAssessment = null;

      if (dbAssessment != null)
      {
        if (dbAssessment.LearnerUserId == this.Actor.UserId || dbAssessment.AssessorUserId == this.Actor.UserId || this.Actor.Roles.Contains("Admin"))
        {
          rtnAssessment = GetAssessmentVM(dbAssessment);
        }
      }

      return rtnAssessment;
    }

    #endregion


    #region Private Functions

    private AssessmentVM GetAssessmentVM(Assessment assessment)
    {
      var dbTopic = TopicService.GetTopic(assessment.TopicId);

      var rtnAssessment = new AssessmentVM(assessment);
      rtnAssessment.Topic = new TopicVM(dbTopic);

      var dbLearner = this.mainContext.Users.Where(u => u.Id == assessment.LearnerUserId).FirstOrDefault();
      if (dbLearner != null)
      {
        rtnAssessment.Learner = new UserVM(dbLearner);
      }

      if (rtnAssessment.AssessorUserId != Guid.Empty)
      {
        var dbAssessor = this.mainContext.Users.Where(u => u.Id == assessment.AssessorUserId).FirstOrDefault();

        if (dbAssessor != null)
        {
          rtnAssessment.Assessor = new UserVM(dbAssessor);
        }
        else
        {
          rtnAssessment.MentorshipId = Guid.Empty;
        }
      }

      return rtnAssessment;
    }
    #endregion
  }
}