using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tete.Web.Migrations
{
  public partial class InitialVote : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Votes",
          columns: table => new
          {
            VoteId = table.Column<Guid>(nullable: false),
            Active = table.Column<bool>(nullable: false),
            Created = table.Column<DateTime>(nullable: false),
            CloseDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Votes", x => x.VoteId);
          });

      migrationBuilder.CreateTable(
          name: "VoteEntries",
          columns: table => new
          {
            VoteEntryId = table.Column<Guid>(nullable: false),
            VoteId = table.Column<Guid>(nullable: false),
            UserId = table.Column<Guid>(nullable: false),
            Submitted = table.Column<bool>(nullable: false),
            Result = table.Column<bool>(nullable: false),
            SubmitDate = table.Column<DateTime>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_VoteEntries", x => x.VoteEntryId);
            table.ForeignKey(
                      name: "FK_VoteEntries_Users_UserId",
                      column: x => x.UserId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_VoteEntries_Votes_VoteId",
                      column: x => x.VoteId,
                      principalTable: "Votes",
                      principalColumn: "VoteId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "VoteMentorApplications",
          columns: table => new
          {
            MentorApplicationId = table.Column<Guid>(nullable: false),
            VoteId = table.Column<Guid>(nullable: false),
            TopicId = table.Column<Guid>(nullable: false),
            UserId = table.Column<Guid>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_VoteMentorApplications", x => x.MentorApplicationId);
            table.ForeignKey(
                      name: "FK_VoteMentorApplications_Topics_TopicId",
                      column: x => x.TopicId,
                      principalTable: "Topics",
                      principalColumn: "TopicId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_VoteMentorApplications_Users_UserId",
                      column: x => x.UserId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_VoteMentorApplications_Votes_VoteId",
                      column: x => x.VoteId,
                      principalTable: "Votes",
                      principalColumn: "VoteId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "VoteTopicChanges",
          columns: table => new
          {
            TopicChangeId = table.Column<Guid>(nullable: false),
            VoteId = table.Column<Guid>(nullable: false),
            TopicId = table.Column<Guid>(nullable: false),
            NewName = table.Column<string>(nullable: true),
            NewDescription = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_VoteTopicChanges", x => x.TopicChangeId);
            table.ForeignKey(
                      name: "FK_VoteTopicChanges_Votes_VoteId",
                      column: x => x.VoteId,
                      principalTable: "Votes",
                      principalColumn: "VoteId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_VoteEntries_UserId",
          table: "VoteEntries",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_VoteEntries_VoteId",
          table: "VoteEntries",
          column: "VoteId");

      migrationBuilder.CreateIndex(
          name: "IX_VoteMentorApplications_TopicId",
          table: "VoteMentorApplications",
          column: "TopicId");

      migrationBuilder.CreateIndex(
          name: "IX_VoteMentorApplications_UserId",
          table: "VoteMentorApplications",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_VoteMentorApplications_VoteId",
          table: "VoteMentorApplications",
          column: "VoteId");

      migrationBuilder.CreateIndex(
          name: "IX_VoteTopicChanges_VoteId",
          table: "VoteTopicChanges",
          column: "VoteId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "VoteEntries");

      migrationBuilder.DropTable(
          name: "VoteMentorApplications");

      migrationBuilder.DropTable(
          name: "VoteTopicChanges");

      migrationBuilder.DropTable(
          name: "Votes");

      migrationBuilder.CreateIndex(
          name: "IX_Assessments_AssessorUserId",
          table: "Assessments",
          column: "AssessorUserId");

      migrationBuilder.AddForeignKey(
          name: "FK_Assessments_Users_AssessorUserId",
          table: "Assessments",
          column: "AssessorUserId",
          principalTable: "Users",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }
  }
}
