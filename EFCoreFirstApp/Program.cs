using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EFCoreFirstApp
{
    /// <summary>
    /// This is a simple entity class
    /// </summary>
    class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfFormation { get; set; }
    }
    /// <summary>
    /// This is a simple entity class
    /// </summary>
    class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }
    }
    /// <summary>
    /// This class handles the database connection and is performing the crud operations
    /// </summary>
    class EFCoreOrganizationDb:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string for database
            optionsBuilder.UseSqlServer(@"Server=MCL-DESKTOP-HOM\SQLEXPRESS;Database=EFCoreOrganization;Trusted_Connection=True;");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EFCoreOrganizationDb efCntx = new EFCoreOrganizationDb();
            // Select all departments
            List<Department> Depts = efCntx.Departments.ToList();

            // Create new entity and add to database
            Department D = new Department() { Description = "Development", Name = "Dev" };
            efCntx.Departments.Add(D);

            efCntx.SaveChanges();

        }
    }
}
