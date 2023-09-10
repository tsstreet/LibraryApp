using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choice_MultipleChoice_MultipleChoiceId",
                table: "Choice");

            migrationBuilder.DropTable(
                name: "MultipleChoice");

            migrationBuilder.RenameColumn(
                name: "MultipleChoiceId",
                table: "Choice",
                newName: "MultipleChoiceQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Choice_MultipleChoiceId",
                table: "Choice",
                newName: "IX_Choice_MultipleChoiceQuestionId");

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestion",
                columns: table => new
                {
                    MultipleChoiceQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestion", x => x.MultipleChoiceQuestionId);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestion_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestion_ExamId",
                table: "MultipleChoiceQuestion",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_MultipleChoiceQuestion_MultipleChoiceQuestionId",
                table: "Choice",
                column: "MultipleChoiceQuestionId",
                principalTable: "MultipleChoiceQuestion",
                principalColumn: "MultipleChoiceQuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choice_MultipleChoiceQuestion_MultipleChoiceQuestionId",
                table: "Choice");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestion");

            migrationBuilder.RenameColumn(
                name: "MultipleChoiceQuestionId",
                table: "Choice",
                newName: "MultipleChoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Choice_MultipleChoiceQuestionId",
                table: "Choice",
                newName: "IX_Choice_MultipleChoiceId");

            migrationBuilder.CreateTable(
                name: "MultipleChoice",
                columns: table => new
                {
                    MultipleChoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoice", x => x.MultipleChoiceId);
                    table.ForeignKey(
                        name: "FK_MultipleChoice_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoice_ExamId",
                table: "MultipleChoice",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_MultipleChoice_MultipleChoiceId",
                table: "Choice",
                column: "MultipleChoiceId",
                principalTable: "MultipleChoice",
                principalColumn: "MultipleChoiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
