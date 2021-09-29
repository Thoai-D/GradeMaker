using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeMaker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstMidName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstMidName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    ClassroomID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassName = table.Column<string>(type: "TEXT", nullable: true),
                    ClassTeacherID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.ClassroomID);
                    table.ForeignKey(
                        name: "FK_Classrooms_Teachers_ClassTeacherID",
                        column: x => x.ClassTeacherID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomStudent",
                columns: table => new
                {
                    ClassroomsClassroomID = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentsID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomStudent", x => new { x.ClassroomsClassroomID, x.StudentsID });
                    table.ForeignKey(
                        name: "FK_ClassroomStudent_Classrooms_ClassroomsClassroomID",
                        column: x => x.ClassroomsClassroomID,
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassroomStudent_Students_StudentsID",
                        column: x => x.StudentsID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomTerms",
                columns: table => new
                {
                    ClassroomTermID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassroomID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassroomTermName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomTerms", x => x.ClassroomTermID);
                    table.ForeignKey(
                        name: "FK_ClassroomTerms_Classrooms_ClassroomID",
                        column: x => x.ClassroomID,
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClassroom",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassroomID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassroom", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentClassroom_Classrooms_ClassroomID",
                        column: x => x.ClassroomID,
                        principalTable: "Classrooms",
                        principalColumn: "ClassroomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClassroom_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GradingSections",
                columns: table => new
                {
                    GradingSectionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Weighting = table.Column<double>(type: "REAL", nullable: false),
                    Score = table.Column<double>(type: "REAL", nullable: false),
                    ClassroomTermID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingSections", x => x.GradingSectionID);
                    table.ForeignKey(
                        name: "FK_GradingSections_ClassroomTerms_ClassroomTermID",
                        column: x => x.ClassroomTermID,
                        principalTable: "ClassroomTerms",
                        principalColumn: "ClassroomTermID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubGradingSections",
                columns: table => new
                {
                    SubGradingSectionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GradingSectionID = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Score = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGradingSections", x => x.SubGradingSectionID);
                    table.ForeignKey(
                        name: "FK_SubGradingSections_GradingSections_GradingSectionID",
                        column: x => x.GradingSectionID,
                        principalTable: "GradingSections",
                        principalColumn: "GradingSectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassroomTermID = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<double>(type: "REAL", nullable: false),
                    EnrollmentItemSubGradingSectionID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_SubGradingSections_EnrollmentItemSubGradingSectionID",
                        column: x => x.EnrollmentItemSubGradingSectionID,
                        principalTable: "SubGradingSections",
                        principalColumn: "SubGradingSectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "FirstMidName", "LastName" },
                values: new object[] { 1, "Thoai", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "FirstMidName", "LastName" },
                values: new object[] { 2, "Khang", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "FirstMidName", "LastName" },
                values: new object[] { 3, "Peter", null });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "ID", "FirstMidName", "LastName" },
                values: new object[] { 1, "John", "Smith" });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "ClassroomID", "ClassName", "ClassTeacherID" },
                values: new object[] { 1, "English", 1 });

            migrationBuilder.InsertData(
                table: "ClassroomTerms",
                columns: new[] { "ClassroomTermID", "ClassroomID", "ClassroomTermName" },
                values: new object[] { 1, 1, "Term 1" });

            migrationBuilder.InsertData(
                table: "ClassroomTerms",
                columns: new[] { "ClassroomTermID", "ClassroomID", "ClassroomTermName" },
                values: new object[] { 2, 1, "Term 2" });

            migrationBuilder.InsertData(
                table: "ClassroomTerms",
                columns: new[] { "ClassroomTermID", "ClassroomID", "ClassroomTermName" },
                values: new object[] { 3, 1, "Term 3" });

            migrationBuilder.InsertData(
                table: "StudentClassroom",
                columns: new[] { "ID", "ClassroomID", "StudentID" },
                values: new object[] { -1, 1, 1 });

            migrationBuilder.InsertData(
                table: "StudentClassroom",
                columns: new[] { "ID", "ClassroomID", "StudentID" },
                values: new object[] { -2, 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentClassroom",
                columns: new[] { "ID", "ClassroomID", "StudentID" },
                values: new object[] { -3, 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_ClassTeacherID",
                table: "Classrooms",
                column: "ClassTeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomStudent_StudentsID",
                table: "ClassroomStudent",
                column: "StudentsID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomTerms_ClassroomID",
                table: "ClassroomTerms",
                column: "ClassroomID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentItemSubGradingSectionID",
                table: "Enrollments",
                column: "EnrollmentItemSubGradingSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_GradingSections_ClassroomTermID",
                table: "GradingSections",
                column: "ClassroomTermID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassroom_ClassroomID",
                table: "StudentClassroom",
                column: "ClassroomID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassroom_StudentID",
                table: "StudentClassroom",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_SubGradingSections_GradingSectionID",
                table: "SubGradingSections",
                column: "GradingSectionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassroomStudent");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "StudentClassroom");

            migrationBuilder.DropTable(
                name: "SubGradingSections");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "GradingSections");

            migrationBuilder.DropTable(
                name: "ClassroomTerms");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
