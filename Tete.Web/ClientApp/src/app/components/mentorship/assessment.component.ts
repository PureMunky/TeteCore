import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { InitService } from "../../services/init.service";
import { UserService } from "../../services/user.service";
import { AssessmentService } from "../../services/assessment.service";
import { Assessment } from '../../models/assessment';
import { User } from '../../models/user';

@Component({
  selector: "teteAssessment",
  templateUrl: "./assessment.component.html"
})
export class AssessmentComponent {
  public currentUser: User = null;
  public currentAssessment: Assessment = null;
  public isAssessor = false;

  public working = {
    assessorComments: '',
    assessorRating: 0
  };

  constructor(private route: ActivatedRoute,
    private userService: UserService,
    private initService: InitService,
    private assessmentService: AssessmentService) {
    initService.Register(() => {
      this.currentUser = userService.CurrentUser();
      this.route.params.subscribe(params => {
        if (params["assessmentId"]) {
          this.load(params["assessmentId"]);
        }
      })
    });
  }

  public load(assessmentId: string) {
    this.assessmentService.GetAssessment(assessmentId).then(a => {
      this.currentAssessment = a;
      this.isAssessor = (this.currentUser.userId == this.currentAssessment.assessorUserId);
    });
  }
}