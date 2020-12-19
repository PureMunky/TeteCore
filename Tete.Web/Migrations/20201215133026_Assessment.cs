using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tete.Web.Migrations
{
  public partial class Assessment : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Assessments",
          columns: table => new
          {
            AssessmentId = table.Column<Guid>(nullable: false),
            TopicId = table.Column<Guid>(nullable: false),
            Active = table.Column<bool>(nullable: false),
            CreatedDate = table.Column<DateTime>(nullable: false),
            MentorshipId = table.Column<Guid>(nullable: false),
            LearnerUserId = table.Column<Guid>(nullable: false),
            LearnerDetails = table.Column<string>(nullable: true),
            AssessorUserId = table.Column<Guid>(nullable: false),
            AssessorDetails = table.Column<string>(nullable: true),
            AssessorComments = table.Column<string>(nullable: true),
            AssessmentResult = table.Column<bool>(nullable: false),
            Score = table.Column<double>(nullable: false),
            AssignedDate = table.Column<DateTime>(nullable: false),
            CompletedDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Assessments", x => x.AssessmentId);
            table.ForeignKey(
                      name: "FK_Assessments_Users_LearnerUserId",
                      column: x => x.LearnerUserId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.NoAction);
            table.ForeignKey(
                      name: "FK_Assessments_Topics_TopicId",
                      column: x => x.TopicId,
                      principalTable: "Topics",
                      principalColumn: "TopicId",
                      onDelete: ReferentialAction.NoAction);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Assessments_AssessorUserId",
          table: "Assessments",
          column: "AssessorUserId");

      migrationBuilder.CreateIndex(
          name: "IX_Assessments_LearnerUserId",
          table: "Assessments",
          column: "LearnerUserId");

      migrationBuilder.CreateIndex(
          name: "IX_Assessments_TopicId",
          table: "Assessments",
          column: "TopicId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Assessments");
    }
  }
}
