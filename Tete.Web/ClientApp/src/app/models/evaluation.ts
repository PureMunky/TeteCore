export class Evaluation {
  public evaluationId: string;
  public mentorshipId: string;
  public userId: string;
  public createdDate: Date;
  public rating: number;
  public comments: string;

  constructor() {
    this.rating = 3;
  }
}