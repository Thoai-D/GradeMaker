using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeMaker.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "GradingSections");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "SubGradingSections",
                newName: "MaxScore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxScore",
                table: "SubGradingSections",
                newName: "Score");

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "GradingSections",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
