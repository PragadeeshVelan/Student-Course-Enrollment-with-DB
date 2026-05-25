using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using Microsoft.Data.SqlClient;

class Program
{
    // public static List<Student> Students_List = new List<Student>();
    // public static List<Course> Courses_List = new List<Course>();
    // public static Dictionary<int , List<int>> std_course = new Dictionary<int, List<int>>();
    public static void Main(String[] args)
    {
        int n;
        while (true)
        {
            Console.WriteLine("\nStudent Course Enrollment System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Add Course");
            Console.WriteLine("4. View Courses");
            Console.WriteLine("5. Enroll Student in Course");
            Console.WriteLine("6. View Courses Enrollments");
            Console.WriteLine("7. View Enrollment for specific Student");
            Console.WriteLine("8. Exit");
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Choose The Option And Enter the Key From 1 - 7 : ");
            string? action =Console.ReadLine();
            if(!int.TryParse(action, out n))
            {
                Console.WriteLine("enter the valid input !");
                continue;
            }
            int decision = Convert.ToInt32(action);
            switch (decision)
            {
                case 1:
                    Actions.Add_Student();
                    break;
                case 2:
                    Actions.View_Students();
                    break;
                case 3:
                    Actions.Add_Course();
                    break;
                case 4:
                    Actions.View_Courses();
                    break;
                case 5:
                    Actions.Enroll_Std_Cour();
                    break;
                case 6:
                    Actions.View_Enrollments();
                    break;
                case 7:
                    Actions.View_Enroll_by_std();
                    return;
                case 8:
                    return;
                default:
                    Console.WriteLine("Enter the Valid option please : ");
                    break;
            }
            
        }
    }
}