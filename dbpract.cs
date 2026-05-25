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
}
------------------------------------------------------------------------
ADO.NET
    static string connectionString = "Server=localhost, 1433;Database=velan_dbconnection;User Id=sa;Password=MyPassword@123;TrustServerCertificate=True;";
    public static void Add_Student()
    {
        Console.Write("Enter the Student ID : ");
        int Std_ID = Convert.ToInt32(Console.ReadLine());
        foreach (Student std in Program.Students_List)
        {
            if (std.Std_Id == Std_ID)
            {
                Console.WriteLine("This Student ID is already exist , Please enter another one : ");
                return;
            }
        }

        Console.Write("Enter the Student Name : ");
        String Std_Name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(Std_Name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }
        
        Console.Write("Enter the Age of the student : ");
        int Std_age = Convert.ToInt32(Console.ReadLine());
        if(Std_age<0 || Std_age > 100)
        {
            Console.WriteLine("Enter the Vaild Age !!");
            return;
        }

        Console.Write("Enter the Email Of the Student : ");
        String Std_Mail = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(Std_Mail))
        {
            Console.WriteLine("Email cannot be empty.");
            return;
        }

        Program.Students_List.Add(new Student(Std_ID , Std_Name , Std_age , Std_Mail));
        using  (SqlConnection connection = new SqlConnection(Actions.connectionString))
        {
            
            string query = "INSERT INTO [std_course].[student] VALUES (@Std_Id, @Std_Name, @Std_age, @Std_Email)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Std_Id", Std_ID);
            cmd.Parameters.AddWithValue("@Std_Name", Std_Name);
            cmd.Parameters.AddWithValue("@Std_age", Std_age);
            cmd.Parameters.AddWithValue("@Std_Email", Std_Mail);

            connection.Open();
            cmd.ExecuteNonQuery();

        }
    }*/