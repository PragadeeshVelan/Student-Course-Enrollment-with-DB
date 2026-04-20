/*using Microsoft.Data.SqlClient;

class Prog
{
    public static void Main(string[] args)
    {
        string connectionString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        
    }
}   



using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSingleFileDemo
{
    // ============================
    // 1️⃣ ENTITY (Represents TABLE)
    // ============================
    public class Student
    {
        public int Id { get; set; }      // Primary Key → Column
        public string Name { get; set; } // Column
        public int Age { get; set; }     // Column
    }

    // ============================
    // 2️⃣ DB CONTEXT (Database Manager)
    // ============================
    public class SchoolContext : DbContext
    {
        // Represents Students table
        public DbSet<Student> Students { get; set; }

        // Connection string configuration
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Server=localhost;Database=SchoolDB;Trusted_Connection=True");
        }
    }

    // ============================
    // 3️⃣ MAIN PROGRAM
    // ============================
    class Program
    {
        static void Main(string[] args)
        {
            // Create context object (this is your DB connection + manager)
            using var context = new SchoolContext();

            Console.WriteLine("EF Core started...\n");

            // ============================
            // CREATE (INSERT)
            // ============================
            var student = new Student
            {
                Name = "Ravi",
                Age = 20
            };

            context.Students.Add(student);
            context.SaveChanges();

            Console.WriteLine("✅ Student inserted.\n");

            // ============================
            // READ (SELECT)
            // ============================
            var students = context.Students.ToList();

            Console.WriteLine("📌 Students in Database:");
            foreach (var s in students)
            {
                Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}");
            }

            // ============================
            // UPDATE
            // ============================
            var firstStudent = context.Students.FirstOrDefault();
            if (firstStudent != null)
            {
                firstStudent.Age = 21;
                context.SaveChanges();
                Console.WriteLine("\n✅ Student updated.");
            }

            // ============================
            // DELETE
            // ============================
            var deleteStudent = context.Students.FirstOrDefault();
            if (deleteStudent != null)
            {
                context.Students.Remove(deleteStudent);
                context.SaveChanges();
                Console.WriteLine("✅ Student deleted.");
            }

            Console.WriteLine("\nEF Core demo finished.");
            Console.ReadLine();
        }
    }
}*/