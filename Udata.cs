using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

public class Student
{
    [Key]
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

/*

"Server=localhost, 1433;Database=velan_dbconnection;User Id=sa;Password=MyPassword@123;TrustServerCertificate=True;"

*/