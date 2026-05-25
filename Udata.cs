using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Std_Id { get; set; }
    public string Std_Name { get; set; } = string.Empty;
    public int Std_age { get; set; }
    public string Std_Email { get; set; } = string.Empty;

    public Student() { }
    public Student(int Std_Id, string Std_Name, int Std_age, string Std_Email)
    {
        this.Std_Id = Std_Id;
        this.Std_Name = Std_Name;
        this.Std_age = Std_age;
        this.Std_Email = Std_Email;
    }
}

public class Course
{
    [Key]
    public int Course_Id { get; set; }
    public string Course_Name { get; set; } = string.Empty;
    public int Course_Hours { get; set; }
    public string Course_Mentor { get; set; } = string.Empty;
    public Course() { }

    public Course(int Course_Id, string Course_Name, int Course_Hours, string Course_Mentor)
    {
        this.Course_Id = Course_Id;
        this.Course_Name = Course_Name;
        this.Course_Hours = Course_Hours;
        this.Course_Mentor = Course_Mentor;
    }
}

public class Enrollment
{
    public int Std_Id { get; set; }
    public int Course_Id { get; set; }
}

public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost, 1433;Database=velan_dbconnection;User Id=sa;Password=MyPassword@123;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable("student", "std_course");
        modelBuilder.Entity<Course>().ToTable("course", "std_course");
        modelBuilder.Entity<Enrollment>().ToTable("enrollment", "std_course");
        modelBuilder.Entity<Enrollment>().HasKey(e => new { e.Std_Id, e.Course_Id });
    }
}