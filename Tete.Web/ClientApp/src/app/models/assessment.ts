import { User } from "./user";

export class Assessment {
  public assessmentId: string;
  public topicId: string;
  public active: boolean;
  public createdDate: Date;
  public menotrshipId: string;
  public learnerUserId: string;
  public learner: User;
  public learnerDetails: string;
  public assessorUserId: string;
  public assessor: User;
  public assessorDetails: string;
  public assessorComments: string;
  public assessmentResult: boolean;
  public score: number;
  public assignedDate: Date;
  public completedDate: Date;
}