using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    /// <inheritdoc />
    public partial class update7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Essay_Exams_ExamId",
                table: "Essay");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceQuestion_Exams_ExamId",
                table: "MultipleChoiceQuestion");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Essay");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Essay",
                newName: "AnswerType");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "MultipleChoiceQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "MultipleChoiceQuestion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Essay",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Essay_Exams_ExamId",
                table: "Essay",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceQuestion_Exams_ExamId",
                table: "MultipleChoiceQuestion",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Essay_Exams_ExamId",
                table: "Essay");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceQuestion_Exams_ExamId",
                table: "MultipleChoiceQuestion");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "MultipleChoiceQuestion");

            migrationBuilder.RenameColumn(
                name: "AnswerType",
                table: "Essay",
                newName: "FilePath");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "MultipleChoiceQuestion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "Essay",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Essay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Essay_Exams_ExamId",
                table: "Essay",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceQuestion_Exams_ExamId",
                table: "MultipleChoiceQuestion",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId");
        }
    }
}
