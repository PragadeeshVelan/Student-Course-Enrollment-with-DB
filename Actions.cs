class Actions
{
    public static void Add_Student()
    {
        while (true)
        {
            Console.Write("Enter the Student Name : ");
            string? Std_Name = Console.ReadLine();
            int temp;

            if (string.IsNullOrWhiteSpace(Std_Name) || int.TryParse(Std_Name, out temp))
            {
                Console.WriteLine("enter the valid name");
                continue;
            }

            Console.Write("Enter the Age of the student : ");
            if (!int.TryParse(Console.ReadLine(), out int Std_age) || Std_age < 0 || Std_age > 100)
            {
                Console.WriteLine("Enter valid age.");
                continue;
            }

            Console.Write("Enter the Email Of the Student : ");
            string? Std_Mail = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Std_Mail) || int.TryParse(Std_Mail, out temp))
            {
                Console.WriteLine("enter the valid email");
                continue;
            }

            using (var context = new SchoolContext())
            {
                var student = new Student
                {
                    Std_Name = Std_Name,
                    Std_age = Std_age,
                    Std_Email = Std_Mail
                };

                context.Students.Add(student);
                context.SaveChanges();
            }
            break;
        }
    }

    public static void View_Students()
    {
        using (var context = new SchoolContext())
        {
            var students = context.Students.ToList();
            
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (Student std in students)
            {
                Console.WriteLine("Student Id : " + std.Std_Id +
                    " , Student Name : " + std.Std_Name +
                    " , Student Age : " + std.Std_age +
                    " , Student Email : " + std.Std_Email);
            }
        }
    }

    public static void Add_Course()
    {
        while (true)
        {
            Console.WriteLine("Enter The Course Id : ");
            if (!int.TryParse(Console.ReadLine(), out int C_Id) || C_Id < 0)
            {
                Console.WriteLine("Invalid Course ID.");
                continue;
            }

            using (var context = new SchoolContext())
            {
                if (context.Courses.Any(c => c.Course_Id == C_Id))
                {
                    Console.WriteLine("This Id is already Registered !");
                    continue;
                }
            }

            Console.WriteLine("Enter the Course Name : ");
            string? C_name = Console.ReadLine();

            int temp;
            if (string.IsNullOrWhiteSpace(C_name) || int.TryParse(C_name, out temp))
            {
                Console.WriteLine("Enter valid name!");
                continue;
            }

            Console.WriteLine("Enter the Course Duration : ");
            if (!int.TryParse(Console.ReadLine(), out int C_Duration) || C_Duration < 0)
            {
                Console.WriteLine("Enter valid duration!");
                continue;
            }

            Console.WriteLine("Enter the mentor name :");
            string? C_mentor = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(C_mentor) || int.TryParse(C_mentor, out temp))
            {
                Console.WriteLine("Enter valid name!");
                continue;
            }

            using (var context = new SchoolContext())
            {
                var course = new Course(C_Id, C_name, C_Duration, C_mentor);
                context.Courses.Add(course);
                context.SaveChanges();
            }
            break;
        }
    }

    public static void View_Courses()
    {
        using (var context = new SchoolContext())
        {
            var courses = context.Courses.ToList();
            
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found.");
                return;
            }

            foreach (Course cr in courses)
            {
                Console.WriteLine("Course Id : " + cr.Course_Id +
                    " , Course Name : " + cr.Course_Name +
                    " , Course Duration : " + cr.Course_Hours +
                    " , Course Mentor : " + cr.Course_Mentor);
            }
        }
    }

    public static void Enroll_Std_Cour()
    {
        int Std_Id;
        while (true)
        {
            Console.Write("Enter the Student Id : ");
            if (!int.TryParse(Console.ReadLine(), out Std_Id))
            {
                Console.WriteLine("Invalid Student ID.");
                continue;
            }

            using (var context = new SchoolContext())
            {
                bool is_std_pre = context.Students.Any(s => s.Std_Id == Std_Id);

                if (!is_std_pre)
                {
                    Console.WriteLine("Student not found.");
                    continue;
                }
            }
            break;
        }

        while (true)
        {
            Console.Write("Enter the Course Id : ");
            if (!int.TryParse(Console.ReadLine(), out int C_Id))
            {
                Console.WriteLine("Invalid Course ID.");
                continue;
            }

            using (var context = new SchoolContext())
            {
                bool is_cr_pre = context.Courses.Any(c => c.Course_Id == C_Id);

                if (!is_cr_pre)
                {
                    Console.WriteLine("Course not found.");
                    continue;
                }

                bool already_enrolled = context.Enrollments.Any(e => e.Std_Id == Std_Id && e.Course_Id == C_Id);

                if (already_enrolled)
                {
                    Console.WriteLine("Student already enrolled.");
                    return;
                }

                var enrollment = new Enrollment { Std_Id = Std_Id, Course_Id = C_Id };
                context.Enrollments.Add(enrollment);
                context.SaveChanges();
            }
            break;
        }
    }

    public static void View_Enrollments()
    {
        using (var context = new SchoolContext())
        {
            var enrollments = context.Enrollments.ToList();
            
            if (enrollments.Count == 0)
            {
                Console.WriteLine("There are no enrollments!");
                return;
            }

            var groupedEnrollments = enrollments.GroupBy(e => e.Std_Id);

            foreach (var group in groupedEnrollments)
            {
                var courseIds = string.Join(", ", group.Select(e => e.Course_Id));
                Console.WriteLine("Student Id : " + group.Key +
                    " Enrolled Courses : " + courseIds);
            }
        }
    }

    public static void View_Enroll_by_std()
    {
        int Std_Id;
        while (true)
        {
            Console.WriteLine("Enter the Student Id : ");
            if (!int.TryParse(Console.ReadLine(), out Std_Id))
            {
                Console.WriteLine("Invalid Student ID.");
                continue;
            }

            using (var context = new SchoolContext())
            {
                var enrolledCourses = context.Enrollments
                    .Where(e => e.Std_Id == Std_Id)
                    .Select(e => e.Course_Id)
                    .ToList();

                if (enrolledCourses.Count == 0)
                {
                    Console.WriteLine("Student not found.");
                    continue;
                }

                Console.WriteLine("Courses enrolled by Student " + Std_Id + ":");

                foreach (var course in enrolledCourses)
                {
                    Console.WriteLine("- " + course);
                }
            }
            break;
        }
    }
}