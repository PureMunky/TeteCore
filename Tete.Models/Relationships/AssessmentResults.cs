using System;

namespace Tete.Models.Relationships
{
  public class AssessmentResults
  {
    public Guid AssessmentId { get; set; }
    public string Comments { get; set; }
    public double Score { get; set; }
    public bool Pass { get; set; }
  }
}