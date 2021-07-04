using Microsoft.EntityFrameworkCore.Migrations;

namespace Ask.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "SubAnswers",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubAnswers",
                newName: "SubAnswerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "QuestionTags",
                newName: "QuestionTagId");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Questions",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Questions",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Answers",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Answers",
                newName: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "SubAnswers",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "SubAnswerId",
                table: "SubAnswers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "QuestionTagId",
                table: "QuestionTags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Questions",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Questions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Answers",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "Answers",
                newName: "Id");
        }
    }
}
