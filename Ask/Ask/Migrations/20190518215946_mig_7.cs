using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ask.Migrations
{
    public partial class mig_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubAnswers");

            migrationBuilder.CreateTable(
                name: "AnswerComments",
                columns: table => new
                {
                    AnswerCommentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    AnswerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerComments", x => x.AnswerCommentId);
                    table.ForeignKey(
                        name: "FK_AnswerComments_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerComments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionComments",
                columns: table => new
                {
                    QuestionCommentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    QuestionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionComments", x => x.QuestionCommentId);
                    table.ForeignKey(
                        name: "FK_QuestionComments_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionComments_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerComments_AnswerId",
                table: "AnswerComments",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerComments_AppUserId",
                table: "AnswerComments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionComments_AppUserId",
                table: "QuestionComments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionComments_QuestionId",
                table: "QuestionComments",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerComments");

            migrationBuilder.DropTable(
                name: "QuestionComments");

            migrationBuilder.CreateTable(
                name: "SubAnswers",
                columns: table => new
                {
                    SubAnswerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerId = table.Column<long>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    CommentedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAnswers", x => x.SubAnswerId);
                    table.ForeignKey(
                        name: "FK_SubAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubAnswers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubAnswers_AnswerId",
                table: "SubAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubAnswers_AppUserId",
                table: "SubAnswers",
                column: "AppUserId");
        }
    }
}
