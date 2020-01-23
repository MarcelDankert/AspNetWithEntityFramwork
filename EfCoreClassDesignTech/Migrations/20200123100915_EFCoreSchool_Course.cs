using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreClassDesignTech.Migrations
{
    public partial class EFCoreSchool_Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "SchoolClassId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SchoolClass",
                columns: table => new
                {
                    SchoolClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolClassName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClass", x => x.SchoolClassId);
                });

            migrationBuilder.CreateTable(
                name: "Student_Course",
                columns: table => new
                {
                    SCid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Course", x => x.SCid);
                    table.ForeignKey(
                        name: "FK_Student_Course_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Course_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolClassId",
                table: "Students",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Course_CourseId",
                table: "Student_Course",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Course_StudentId",
                table: "Student_Course",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SchoolClass_SchoolClassId",
                table: "Students",
                column: "SchoolClassId",
                principalTable: "SchoolClass",
                principalColumn: "SchoolClassId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_SchoolClass_SchoolClassId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "SchoolClass");

            migrationBuilder.DropTable(
                name: "Student_Course");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolClassId",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
