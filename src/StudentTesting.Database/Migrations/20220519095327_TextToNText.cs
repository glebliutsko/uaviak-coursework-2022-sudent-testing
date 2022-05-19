using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Database.Migrations
{
    public partial class TextToNText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tests",
                type: "NTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Questions",
                type: "NTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courses",
                type: "NTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Answers",
                type: "NTEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Questions",
                type: "TEXT",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Answers",
                type: "TEXT",
                nullable: false);
        }
    }
}
