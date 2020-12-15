import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { InitService } from "../../services/init.service";
import { UserService } from "../../services/user.service";
import { Mentorship } from '../../models/mentorship';
import { User } from '../../models/user';

@Component({
  selector: "teteAssessment",
  templateUrl: "./assessment.component.html"
})
export class AssessmentComponent {
  public currentUser: User = null;
  public working = {
    assessorComments: '',
    assessorRating: 0
  };

  constructor(private route: ActivatedRoute,
    private userService: UserService,
    private initService: InitService) {
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

  }
}