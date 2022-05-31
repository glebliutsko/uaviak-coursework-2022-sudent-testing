using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Database.Migrations
{
    public partial class RemoveAttemtAndTypeQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerQuestionAttemt");

            migrationBuilder.DropTable(
                name: "QuestionAttemts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Attempts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Attempts");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Questions",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "QuestionAttemts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttemptId = table.Column<int>(type: "int", nullable: false),
                    ToQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAttemts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAttemts_Attempts_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "Attempts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAttemts_Questions_ToQuestionId",
                        column: x => x.ToQuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnswerQuestionAttemt",
                columns: table => new
                {
                    AnswersId = table.Column<int>(type: "int", nullable: false),
                    QuestionAttemtsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestionAttemt", x => new { x.AnswersId, x.QuestionAttemtsId });
                    table.ForeignKey(
                        name: "FK_AnswerQuestionAttemt_Answers_AnswersId",
                        column: x => x.AnswersId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerQuestionAttemt_QuestionAttemts_QuestionAttemtsId",
                        column: x => x.QuestionAttemtsId,
                        principalTable: "QuestionAttemts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestionAttemt_QuestionAttemtsId",
                table: "AnswerQuestionAttemt",
                column: "QuestionAttemtsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAttemts_AttemptId",
                table: "QuestionAttemts",
                column: "AttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAttemts_ToQuestionId",
                table: "QuestionAttemts",
                column: "ToQuestionId");
        }
    }
}
