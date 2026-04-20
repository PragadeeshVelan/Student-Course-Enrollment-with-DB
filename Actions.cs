using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Data.SqlClient;

class Actions
{
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
    }
    public static void View_Students()
    {        
    List<Student> dbstd = new List<Student>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Std_Id, Std_Name, Std_age, Std_Email FROM [std_course].[student]";
            
        SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dbstd.Add(new Student
                {
                    Std_Id = Convert.ToInt32(reader["Std_Id"]),
                    Std_Name = reader["Std_Name"].ToString(),
                    Std_age = Convert.ToInt32(reader["Std_age"]),
                    Std_Email = reader["Std_Email"].ToString()
                });         
            }
        }
        foreach (Student std in dbstd)
        {
            Console.WriteLine("Student Id : " + std.Std_Id + " , Student Name : " + std.Std_Name + " , Student Age : " + std.Std_age + " , Student Email : " + std.Std_Email);
        }
        
    }
    public static void Add_Course()
    {
        Console.WriteLine("Enter The Course Id : ");
        int C_Id = Convert.ToInt32(Console.ReadLine());
        foreach (Course cr in Program.Courses_List)
        {
            if(cr.Course_Id == C_Id)
            {
                Console.WriteLine("This Id is already Registered !");
                return;
            }
        }

        Console.WriteLine("Enter the Course Name : ");
        String C_name = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(C_name))
        {
            Console.WriteLine("Enter the valid name !");
            return;
        }

        Console.WriteLine("Enter the Course Duration : ");
        int C_Duration = Convert.ToInt32(Console.ReadLine());
        if(C_Duration < 0)
        {
            Console.WriteLine("Enter the Valid Duration !");
            return;
        }

        Console.WriteLine("Enter the mentor name :");
        String C_mentor = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(C_mentor))
        {
            Console.WriteLine("Enter the vaild name !");
            return;
        }

        Program.Courses_List.Add(new Course(C_Id , C_name , C_Duration , C_mentor));

        using  (SqlConnection connection = new SqlConnection(Actions.connectionString))
        {
            
            string query = "INSERT INTO [std_course].[course] VALUES (@C_Id, @C_name, @C_Duration, @C_mentor)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@C_Id", C_Id);
            cmd.Parameters.AddWithValue("@C_name", C_name);
            cmd.Parameters.AddWithValue("@C_Duration", C_Duration);
            cmd.Parameters.AddWithValue("@C_mentor", C_mentor);

            connection.Open();
            cmd.ExecuteNonQuery();

        }
        
    }
    public static void View_Courses()
    {
        List<Course> dbcourses = new List<Course>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Course_Id, Course_Name, Course_Hours, Course_Mentor FROM [std_course].[course]";
            
        SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dbcourses.Add(new Course
                {
                    Course_Id = Convert.ToInt32(reader["Course_Id"]),
                    Course_Name = reader["Course_Name"].ToString(),
                    Course_Hours = Convert.ToInt32(reader["Course_Hours"]),
                    Course_Mentor = reader["Course_Mentor"].ToString()
                });         
            }
        }
        foreach (Course std in dbcourses)
        {
            Console.WriteLine("Course Id : " + std.Course_Id + " , Course Name : " + std.Course_Name + " , Course Hours : " + std.Course_Hours + " , Course Mentor : " + std.Course_Mentor);
        }
        
    }
    public static void Enroll_Std_Cour()
    {
        Console.Write("Enter the Student Id : ");
        int Std_Id = Convert.ToInt32(Console.ReadLine());
        bool is_std_pre = true;
        foreach (Student std in Program.Students_List)
        {
            if (std.Std_Id == Std_Id)
            {
                is_std_pre = true;
                break;
            }
        }
        if (!is_std_pre)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter the Course Id : ");
        int C_Id = Convert.ToInt32(Console.ReadLine());
        bool is_cr_pre = false;
        foreach (Course cr in Program.Courses_List)
        {
            if (cr.Course_Id == C_Id)
            {
                is_cr_pre = true;
                break;
            }
        }
        if (!is_cr_pre)
        {
            Console.WriteLine("Course not found.");
            return;
        }

        if (!Program.std_course.ContainsKey(Std_Id))
        {
            Program.std_course[Std_Id] = new List<int>();
        }
        if (Program.std_course[Std_Id].Contains(C_Id))
            {
                Console.WriteLine("Student is already enrolled in this course.");
                return;
            }
        Program.std_course[Std_Id].Add(C_Id);

    }
    public static void View_Enrollments()
    {
        if(Program.std_course.Count == 0)
        {
            Console.WriteLine("There is no students enrolled !");
            return;
        }
        foreach (var ite in Program.std_course)
        {
            Console.WriteLine("Student Id : " + ite.Key + "Enroled Courses :" + string.Join(", ", ite.Value));
        }
    }
    public static void View_Enroll_by_std()
    {
        Console.WriteLine("Enter the Student Id : ");
        int Std_Id = Convert.ToInt32(Console.ReadLine());
        if (!Program.std_course.ContainsKey(Std_Id))
        {
            Console.WriteLine("Student not found.");
            return;
        }
        Console.WriteLine("Courses enrolled by Student " + Std_Id + ":");
        foreach (var course in Program.std_course[Std_Id])
        {
            Console.WriteLine("- " + course);
        }
    }
}