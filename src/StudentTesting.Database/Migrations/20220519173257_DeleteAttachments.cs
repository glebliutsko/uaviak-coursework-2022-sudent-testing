using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Database.Migrations
{
    public partial class DeleteAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentsAnswer");

            migrationBuilder.DropTable(
                name: "AttachmentsQuestion");

            migrationBuilder.DropTable(
                name: "AttachmentsTest");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Questions",
                type: "NTEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NTEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Answers",
                type: "NTEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NTEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Questions",
                type: "NTEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NTEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Answers",
                type: "NTEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NTEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Mime = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
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
                        principalColumn: "Id");
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttachmentsQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttachmentsTest_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }
    }
}
