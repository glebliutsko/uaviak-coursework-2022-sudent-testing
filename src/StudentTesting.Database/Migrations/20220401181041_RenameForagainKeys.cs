using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Database.Migrations
{
    public partial class RenameForagainKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_IdQuestion",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerHistory_TestTakingHistory_IdTestTakingHistory",
                table: "QuestionAnswerHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_IdTest",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Subjects_IdSubject",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_CreatorId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_TestTakingHistory_Tests_IdTest",
                table: "TestTakingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TestTakingHistory_Users_IsUser",
                table: "TestTakingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_IdGroup",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdCreator",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "IdGroup",
                table: "Users",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdGroup",
                table: "Users",
                newName: "IX_Users_GroupId");

            migrationBuilder.RenameColumn(
                name: "IsUser",
                table: "TestTakingHistory",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdTest",
                table: "TestTakingHistory",
                newName: "TestId");

            migrationBuilder.RenameIndex(
                name: "IX_TestTakingHistory_IsUser",
                table: "TestTakingHistory",
                newName: "IX_TestTakingHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TestTakingHistory_IdTest",
                table: "TestTakingHistory",
                newName: "IX_TestTakingHistory_TestId");

            migrationBuilder.RenameColumn(
                name: "IdSubject",
                table: "Tests",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_IdSubject",
                table: "Tests",
                newName: "IX_Tests_SubjectId");

            migrationBuilder.RenameColumn(
                name: "IdTest",
                table: "Questions",
                newName: "TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_IdTest",
                table: "Questions",
                newName: "IX_Questions_TestId");

            migrationBuilder.RenameColumn(
                name: "IdTestTakingHistory",
                table: "QuestionAnswerHistory",
                newName: "TestTakingHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswerHistory_IdTestTakingHistory",
                table: "QuestionAnswerHistory",
                newName: "IX_QuestionAnswerHistory_TestTakingHistoryId");

            migrationBuilder.RenameColumn(
                name: "IdQuestion",
                table: "Answers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_IdQuestion",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerHistory_TestTakingHistory_TestTakingHistoryId",
                table: "QuestionAnswerHistory",
                column: "TestTakingHistoryId",
                principalTable: "TestTakingHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Subjects_SubjectId",
                table: "Tests",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_CreatorId",
                table: "Tests",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestTakingHistory_Tests_TestId",
                table: "TestTakingHistory",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestTakingHistory_Users_UserId",
                table: "TestTakingHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerHistory_TestTakingHistory_TestTakingHistoryId",
                table: "QuestionAnswerHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Subjects_SubjectId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_CreatorId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_TestTakingHistory_Tests_TestId",
                table: "TestTakingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TestTakingHistory_Users_UserId",
                table: "TestTakingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Users",
                newName: "IdGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                newName: "IX_Users_IdGroup");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TestTakingHistory",
                newName: "IsUser");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "TestTakingHistory",
                newName: "IdTest");

            migrationBuilder.RenameIndex(
                name: "IX_TestTakingHistory_UserId",
                table: "TestTakingHistory",
                newName: "IX_TestTakingHistory_IsUser");

            migrationBuilder.RenameIndex(
                name: "IX_TestTakingHistory_TestId",
                table: "TestTakingHistory",
                newName: "IX_TestTakingHistory_IdTest");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Tests",
                newName: "IdSubject");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_SubjectId",
                table: "Tests",
                newName: "IX_Tests_IdSubject");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Questions",
                newName: "IdTest");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                newName: "IX_Questions_IdTest");

            migrationBuilder.RenameColumn(
                name: "TestTakingHistoryId",
                table: "QuestionAnswerHistory",
                newName: "IdTestTakingHistory");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswerHistory_TestTakingHistoryId",
                table: "QuestionAnswerHistory",
                newName: "IX_QuestionAnswerHistory_IdTestTakingHistory");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answers",
                newName: "IdQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                newName: "IX_Answers_IdQuestion");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Tests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCreator",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_IdQuestion",
                table: "Answers",
                column: "IdQuestion",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerHistory_TestTakingHistory_IdTestTakingHistory",
                table: "QuestionAnswerHistory",
                column: "IdTestTakingHistory",
                principalTable: "TestTakingHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_IdTest",
                table: "Questions",
                column: "IdTest",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Subjects_IdSubject",
                table: "Tests",
                column: "IdSubject",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_CreatorId",
                table: "Tests",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestTakingHistory_Tests_IdTest",
                table: "TestTakingHistory",
                column: "IdTest",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestTakingHistory_Users_IsUser",
                table: "TestTakingHistory",
                column: "IsUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_IdGroup",
                table: "Users",
                column: "IdGroup",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
