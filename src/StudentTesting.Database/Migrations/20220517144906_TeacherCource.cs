using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Database.Migrations
{
    public partial class TeacherCource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherEditorCourse");

            migrationBuilder.AddColumn<int>(
                name: "OwnerCourceId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OwnerCourceId",
                table: "Courses",
                column: "OwnerCourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_OwnerCourceId",
                table: "Courses",
                column: "OwnerCourceId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_OwnerCourceId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_OwnerCourceId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "OwnerCourceId",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "TeacherEditorCourse",
                columns: table => new
                {
                    AvaibleCourseForEditId = table.Column<int>(type: "int", nullable: false),
                    AvaibleForEditId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherEditorCourse", x => new { x.AvaibleCourseForEditId, x.AvaibleForEditId });
                    table.ForeignKey(
                        name: "FK_TeacherEditorCourse_Courses_AvaibleCourseForEditId",
                        column: x => x.AvaibleCourseForEditId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherEditorCourse_Users_AvaibleForEditId",
                        column: x => x.AvaibleForEditId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherEditorCourse_AvaibleForEditId",
                table: "TeacherEditorCourse",
                column: "AvaibleForEditId");
        }
    }
}
