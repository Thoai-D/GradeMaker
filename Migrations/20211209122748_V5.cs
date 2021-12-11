using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeMaker.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_SubGradingSections_EnrollmentItemSubGradingSectionID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_EnrollmentItemSubGradingSectionID",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "EnrollmentItemSubGradingSectionID",
                table: "Enrollments");

            migrationBuilder.AddColumn<int>(
                name: "SubGradingSectionID",
                table: "Enrollments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SubGradingSectionID",
                table: "Enrollments",
                column: "SubGradingSectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_SubGradingSections_SubGradingSectionID",
                table: "Enrollments",
                column: "SubGradingSectionID",
                principalTable: "SubGradingSections",
                principalColumn: "SubGradingSectionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_SubGradingSections_SubGradingSectionID",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_SubGradingSectionID",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "SubGradingSectionID",
                table: "Enrollments");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentItemSubGradingSectionID",
                table: "Enrollments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentItemSubGradingSectionID",
                table: "Enrollments",
                column: "EnrollmentItemSubGradingSectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_SubGradingSections_EnrollmentItemSubGradingSectionID",
                table: "Enrollments",
                column: "EnrollmentItemSubGradingSectionID",
                principalTable: "SubGradingSections",
                principalColumn: "SubGradingSectionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
