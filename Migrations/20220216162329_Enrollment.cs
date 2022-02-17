using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeMaker.Migrations
{
    public partial class Enrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "ClassroomTerms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClassroomTermID",
                table: "Enrollments",
                column: "ClassroomTermID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomTerms_StudentID",
                table: "ClassroomTerms",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomTerms_Students_StudentID",
                table: "ClassroomTerms",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_ClassroomTerms_ClassroomTermID",
                table: "Enrollments",
                column: "ClassroomTermID",
                principalTable: "ClassroomTerms",
                principalColumn: "ClassroomTermID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomTerms_Students_StudentID",
                table: "ClassroomTerms");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_ClassroomTerms_ClassroomTermID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_ClassroomTermID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_ClassroomTerms_StudentID",
                table: "ClassroomTerms");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "ClassroomTerms");
        }
    }
}
