using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tete.Web.Migrations
{
  public partial class VoteTopicId : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<Guid>(
          name: "TopicId",
          table: "Votes",
          nullable: false,
          defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

      migrationBuilder.AddForeignKey(
          name: "FK_Votes_Topic_TopicId",
          table: "Votes",
          column: "TopicId",
          principalTable: "Topics",
          principalColumn: "TopicId",
          onDelete: ReferentialAction.NoAction);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Votes_Topic_TopicId",
          table: "Votes");

      migrationBuilder.DropColumn(
          name: "TopicId",
          table: "Votes");


    }
  }
}
