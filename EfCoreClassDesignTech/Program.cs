using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCoreClassDesignTech
{
    // 1:n Beziehung zwischen SchoolClass und Student
    class SchoolClass
    {
        [Key]
        public int SchoolClassId { get; set; }
        public string SchoolClassName { get; set; }
        public string Description { get; set; }
        public List<Student> Students { get; set; }
    }

    // n:m Beziehung zwischen Course und Student => Assoziationsklasse Student_Course
    class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public List<Student_Course> Student_Courses { get; set; }
        public List<Exam> Exams { get; set; }

    }

    class Student_Course
    {
        [Key]
        public int SCid { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }

    class Exam
    {
        [Key]
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Marks { get; set; }
    }

    class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public int CourseId { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public List<Student_Course> Student_Courses { get; set; }
        public List<Exam> Exams { get; set; }

    }

    /// <summary>
    /// This class handles the database connection and is performing the crud operations
    /// </summary>
    class SchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string for database
            optionsBuilder.UseSqlServer(@"Server=MCL-DESKTOP-HOM\SQLEXPRESS;Database=EFCoreSchool;Trusted_Connection=True;");
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student_Course> Student_Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }


        class Program
        {

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}
