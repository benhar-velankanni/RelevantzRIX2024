namespace AttendanceTracker
{
    class Program
    {
        private static readonly AttendanceManager attendanceManager = new AttendanceManager();
        private static readonly List<Student> allStudents = new List<Student>();

        static void Main(string[] args)
        {
            Console.WriteLine("=== Student Attendance Tracking System ===");
            
            InitializeStudents();
            
            while (true)
            {
                ShowMenu();
                var choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        MarkStudentPresent();
                        break;
                    case 2:
                        RemoveStudentFromAttendance();
                        break;
                    case 3:
                        attendanceManager.DisplayAttendance();
                        break;
                    case 4:
                        ShowAllStudents();
                        break;
                    case 5:
                        AddNewStudent();
                        break;
                    case 6:
                        attendanceManager.ClearAttendance();
                        break;
                    case 7:
                        Console.WriteLine("Thank you for using the Attendance System!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void InitializeStudents()
        {
            allStudents.Add(new Student(1, "Aarav", "10A"));
            allStudents.Add(new Student(2, "Diya", "10A"));
            allStudents.Add(new Student(3, "Karthik", "10B"));
            allStudents.Add(new Student(4, "Priya", "10A"));
            allStudents.Add(new Student(5, "Arjun", "10B"));
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n=== ATTENDANCE MENU ===");
            Console.WriteLine("1. Mark Student Present");
            Console.WriteLine("2. Remove Student from Attendance");
            Console.WriteLine("3. Display Current Attendance");
            Console.WriteLine("4. Show All Students");
            Console.WriteLine("5. Add New Student");
            Console.WriteLine("6. Clear All Attendance");
            Console.WriteLine("7. Exit");
            Console.Write("\nEnter your choice (1-7): ");
        }

        static int GetUserChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            return 0;
        }

        static void MarkStudentPresent()
        {
            Console.WriteLine("\n=== Mark Student Present ===");
            
            if (allStudents.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            Console.WriteLine("Available Students:");
            for (int i = 0; i < allStudents.Count; i++)
            {
                var status = attendanceManager.IsStudentPresent(allStudents[i]) ? " (Already Present)" : "";
                Console.WriteLine($"{i + 1}. {allStudents[i]} - Class: {allStudents[i].Class}{status}");
            }

            Console.Write("\nEnter student number: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && 
                choice >= 1 && choice <= allStudents.Count)
            {
                attendanceManager.MarkPresent(allStudents[choice - 1]);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void RemoveStudentFromAttendance()
        {
            Console.WriteLine("\n=== Remove Student from Attendance ===");
            
            var presentStudents = attendanceManager.GetPresentStudents();
            if (presentStudents.Count == 0)
            {
                Console.WriteLine("No students are currently present.");
                return;
            }

            Console.WriteLine("Present Students:");
            for (int i = 0; i < presentStudents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {presentStudents[i]}");
            }

            Console.Write("\nEnter student number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && 
                choice >= 1 && choice <= presentStudents.Count)
            {
                attendanceManager.RemoveStudent(presentStudents[choice - 1]);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void ShowAllStudents()
        {
            Console.WriteLine("\n=== All Students ===");
            
            if (allStudents.Count == 0)
            {
                Console.WriteLine("No students registered.");
                return;
            }

            Console.WriteLine($"Total Students: {allStudents.Count}");
            Console.WriteLine($"Present Today: {attendanceManager.GetPresentCount()}\n");

            foreach (var student in allStudents)
            {
                var status = attendanceManager.IsStudentPresent(student) ? "Present" : "Absent";
                Console.WriteLine($"{student} - Class: {student.Class} - Status: {status}");
            }
        }

        static void AddNewStudent()
        {
            Console.WriteLine("\n=== Add New Student ===");
            
            Console.Write("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            if (allStudents.Any(s => s.Id == id))
            {
                Console.WriteLine("Student with this ID already exists.");
                return;
            }

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            Console.Write("Enter Class: ");
            string className = Console.ReadLine()?.Trim() ?? "";

            var newStudent = new Student(id, name, className);
            allStudents.Add(newStudent);
            Console.WriteLine($"Student {name} added successfully!");
        }
    }
}