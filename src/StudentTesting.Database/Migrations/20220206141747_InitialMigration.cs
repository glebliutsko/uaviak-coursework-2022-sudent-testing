using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Mime = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR(64)", maxLength: 64, nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    DocumentNumber = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    IdGroup = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_IdGroup",
                        column: x => x.IdGroup,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IdCreator = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentsTest",
                columns: table => new
                {
                    AttachmentsId = table.Column<int>(type: "int", nullable: false),
                    TestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsTest", x => new { x.AttachmentsId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_AttachmentsTest_Attachments_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentsTest_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupTest",
                columns: table => new
                {
                    AllowGroupsId = table.Column<int>(type: "int", nullable: false),
                    AvailableTestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTest", x => new { x.AllowGroupsId, x.AvailableTestsId });
                    table.ForeignKey(
                        name: "FK_GroupTest_Groups_AllowGroupsId",
                        column: x => x.AllowGroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTest_Tests_AvailableTestsId",
                        column: x => x.AvailableTestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IdTest = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_IdTest",
                        column: x => x.IdTest,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestTakingHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IdTest = table.Column<int>(type: "int", nullable: false),
                    IsUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTakingHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestTakingHistory_Tests_IdTest",
                        column: x => x.IdTest,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestTakingHistory_Users_IsUser",
                        column: x => x.IsUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IdQuestion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_IdQuestion",
                        column: x => x.IdQuestion,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentsQuestion",
                columns: table => new
                {
                    AttachmentsId = table.Column<int>(type: "int", nullable: false),
                    QuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsQuestion", x => new { x.AttachmentsId, x.QuestionsId });
                    table.ForeignKey(
                        name: "FK_AttachmentsQuestion_Attachments_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentsQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswerHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTestTakingHistory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswerHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswerHistory_TestTakingHistory_IdTestTakingHistory",
                        column: x => x.IdTestTakingHistory,
                        principalTable: "TestTakingHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentsAnswer",
                columns: table => new
                {
                    AnswersId = table.Column<int>(type: "int", nullable: false),
                    AttachmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentsAnswer", x => new { x.AnswersId, x.AttachmentsId });
                    table.ForeignKey(
                        name: "FK_AttachmentsAnswer_Answers_AnswersId",
                        column: x => x.AnswersId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentsAnswer_Attachments_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerQuestionAnswerHistory",
                columns: table => new
                {
                    AnswersId = table.Column<int>(type: "int", nullable: false),
                    TestTakingHistoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestionAnswerHistory", x => new { x.AnswersId, x.TestTakingHistoriesId });
                    table.ForeignKey(
                        name: "FK_AnswerQuestionAnswerHistory_Answers_AnswersId",
                        column: x => x.AnswersId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerQuestionAnswerHistory_QuestionAnswerHistory_TestTakingHistoriesId",
                        column: x => x.TestTakingHistoriesId,
                        principalTable: "QuestionAnswerHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestionAnswerHistory_TestTakingHistoriesId",
                table: "AnswerQuestionAnswerHistory",
                column: "TestTakingHistoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_IdQuestion",
                table: "Answers",
                column: "IdQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentsAnswer_AttachmentsId",
                table: "AttachmentsAnswer",
                column: "AttachmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentsQuestion_QuestionsId",
                table: "AttachmentsQuestion",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentsTest_TestsId",
                table: "AttachmentsTest",
                column: "TestsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTest_AvailableTestsId",
                table: "GroupTest",
                column: "AvailableTestsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerHistory_IdTestTakingHistory",
                table: "QuestionAnswerHistory",
                column: "IdTestTakingHistory");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdTest",
                table: "Questions",
                column: "IdTest");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CreatorId",
                table: "Tests",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TestTakingHistory_IdTest",
                table: "TestTakingHistory",
                column: "IdTest");

            migrationBuilder.CreateIndex(
                name: "IX_TestTakingHistory_IsUser",
                table: "TestTakingHistory",
                column: "IsUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdGroup",
                table: "Users",
                column: "IdGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerQuestionAnswerHistory");

            migrationBuilder.DropTable(
                name: "AttachmentsAnswer");

            migrationBuilder.DropTable(
                name: "AttachmentsQuestion");

            migrationBuilder.DropTable(
                name: "AttachmentsTest");

            migrationBuilder.DropTable(
                name: "GroupTest");

            migrationBuilder.DropTable(
                name: "QuestionAnswerHistory");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "TestTakingHistory");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
