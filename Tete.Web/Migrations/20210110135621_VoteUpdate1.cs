using Microsoft.EntityFrameworkCore.Migrations;

namespace Tete.Web.Migrations
{
    public partial class VoteUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Votes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Votes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Votes");
        }
    }
}
