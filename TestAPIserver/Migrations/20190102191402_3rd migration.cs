using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPIserver.Migrations
{
    public partial class _3rdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Income",
                table: "Surveys",
                newName: "Reward");

            migrationBuilder.RenameColumn(
                name: "_OpenAnswer",
                table: "OpenAnswer",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "UserResponse",
                table: "OpenAnswer",
                newName: "Response");

            migrationBuilder.RenameColumn(
                name: "_ClosedAnswer",
                table: "ClosedAnswer",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Answered",
                table: "ClosedAnswer",
                newName: "Response");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Reward",
                table: "Surveys",
                newName: "Income");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "OpenAnswer",
                newName: "_OpenAnswer");

            migrationBuilder.RenameColumn(
                name: "Response",
                table: "OpenAnswer",
                newName: "UserResponse");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ClosedAnswer",
                newName: "_ClosedAnswer");

            migrationBuilder.RenameColumn(
                name: "Response",
                table: "ClosedAnswer",
                newName: "Answered");
        }
    }
}
