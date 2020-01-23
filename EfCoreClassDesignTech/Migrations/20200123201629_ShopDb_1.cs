using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreClassDesignTech.Migrations
{
    public partial class ShopDb_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Courses_CourseId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Students_StudentId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_Courses_CourseId",
                table: "Student_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_Students_StudentId",
                table: "Student_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_SchoolClass_SchoolClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Course",
                table: "Student_Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClass",
                table: "SchoolClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.RenameTable(
                name: "Student_Course",
                newName: "Student_Courses");

            migrationBuilder.RenameTable(
                name: "SchoolClass",
                newName: "SchoolClasses");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Course_StudentId",
                table: "Student_Courses",
                newName: "IX_Student_Courses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Course_CourseId",
                table: "Student_Courses",
                newName: "IX_Student_Courses_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_StudentId",
                table: "Exams",
                newName: "IX_Exams_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_CourseId",
                table: "Exams",
                newName: "IX_Exams_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Courses",
                table: "Student_Courses",
                column: "SCid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses",
                column: "SchoolClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Students_StudentId",
                table: "Exams",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_Courses_CourseId",
                table: "Student_Courses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_Students_StudentId",
                table: "Student_Courses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SchoolClasses_SchoolClassId",
                table: "Students",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "SchoolClassId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Students_StudentId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_Courses_CourseId",
                table: "Student_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_Students_StudentId",
                table: "Student_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_SchoolClasses_SchoolClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Courses",
                table: "Student_Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "Student_Courses",
                newName: "Student_Course");

            migrationBuilder.RenameTable(
                name: "SchoolClasses",
                newName: "SchoolClass");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Courses_StudentId",
                table: "Student_Course",
                newName: "IX_Student_Course_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Courses_CourseId",
                table: "Student_Course",
                newName: "IX_Student_Course_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_StudentId",
                table: "Exam",
                newName: "IX_Exam_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_CourseId",
                table: "Exam",
                newName: "IX_Exam_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Course",
                table: "Student_Course",
                column: "SCid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClass",
                table: "SchoolClass",
                column: "SchoolClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Courses_CourseId",
                table: "Exam",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Students_StudentId",
                table: "Exam",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_Courses_CourseId",
                table: "Student_Course",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_Students_StudentId",
                table: "Student_Course",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SchoolClass_SchoolClassId",
                table: "Students",
                column: "SchoolClassId",
                principalTable: "SchoolClass",
                principalColumn: "SchoolClassId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
