using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentTesting.Database.Migrations
{
    public partial class AddPictureTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Tests",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Tests");
        }
    }
}
