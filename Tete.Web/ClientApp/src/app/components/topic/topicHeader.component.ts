import { Component, Input } from '@angular/core';
import { User } from '../../models/user';
import { Topic } from '../../models/topic';

@Component({
  selector: 'teteTopicHeader',
  templateUrl: './topicHeader.component.html'
})
export class TopicHeader {
  @Input('topic') topic: Topic;
  @Input('currentUser') currentUser: User;
  @Input('learner') learner: User;
  @Input('mentor') mentor: User;
  @Input('mentorTitle') mentorTitle: string;

  public userTitle() {
    var rtnTitle = '';

    if (this.learner && this.currentUser && this.learner.userId == this.currentUser.userId) {
      rtnTitle = 'a Learner';
    } else if (this.mentor && this.currentUser && this.mentor.userId == this.currentUser.userId) {
      rtnTitle = this.mentorTitle;
    }

    return rtnTitle;
  }

  public otherPerson() {
    var rtnPerson = null

    if (this.learner && this.currentUser && this.learner.userId == this.currentUser.userId) {
      rtnPerson = this.mentor;
    } else if (this.mentor && this.currentUser && this.mentor.userId == this.currentUser.userId) {
      rtnPerson = this.learner;
    }

    return rtnPerson;
  }
}