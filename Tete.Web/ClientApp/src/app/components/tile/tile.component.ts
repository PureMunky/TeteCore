import { Component, Input } from '@angular/core';
import { Topic } from 'src/app/models/topic';
import { Mentorship } from 'src/app/models/mentorship';
import { User } from 'src/app/models/user';
import { Assessment } from 'src/app/models/assessment';
import { InitService } from '../../services/init.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'teteTile',
  templateUrl: './tile.component.html'
})
export class TileComponent {
  @Input('topic') topic: Topic;
  @Input('mentorship') mentorship: Mentorship;
  @Input('assessment') assessment: Assessment;

  public currentUser: User;

  constructor(private initService: InitService,
    private userService: UserService) {
    initService.Register(() => {
      this.currentUser = userService.CurrentUser()
    });
  }
}