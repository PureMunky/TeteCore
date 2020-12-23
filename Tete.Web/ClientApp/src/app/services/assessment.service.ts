import { Injectable, Inject } from "@angular/core";
import { ApiService } from "./api.service";
import { Assessment } from "../models/assessment";

@Injectable({
  providedIn: "root"
})
export class AssessmentService {
  private UrlGetAssessment = (assessmentId: string) => `/V1/Assessment/GetAssessment?AssessmentId=${assessmentId}`;
  private UrlGetUserAssessments = (userId: string) => `/V1/Assessment/GetUserAssessments?UserId=${userId}`;
  private UrlSetContactDetails = "/V1/Mentorship/SetContactDetails";

  constructor(private apiService: ApiService) {

  }

  public GetAssessment(assessmentId: string) {
    return this.apiService.get(this.UrlGetAssessment(assessmentId), 100000).then(a => {
      return a[0];
    });
  }

  public GetUserAssessments(userId: string) {
    return this.apiService.get(this.UrlGetUserAssessments(userId), 100000).then(a => a);
  }

  public SetContactDetails(mentorshipId: string, userId: string, contactDetails: string) {
    return this.apiService.post(this.UrlSetContactDetails, {
      mentorshipId: mentorshipId,
      userId: userId,
      ContactDetails: contactDetails
    }, [
      // this.UrlGetMentorship(mentorshipId)
    ]).then(m => {
      return m[0];
    });
  }

  public CloseAssessment(results) {
    this.apiService.post("/V1/Assessment/CloseAssessment", results).then(a => {
      a[0];
    });
  }

}
