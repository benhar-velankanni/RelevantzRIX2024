namespace EmployeeHeirarchy
{
    public abstract class Employee
    {
        public string? Name { get; set; }
        public abstract decimal CalculateSalary();
    }

    public class Manager : Employee
    {
        public override decimal CalculateSalary()
        {
            return 12000m;
        }
    }

    public class Developer : Employee
    {
        public override decimal CalculateSalary()
        {
            return 10000m;
        }
    }

    public class Program
    {
        private static List<Manager> managers = new List<Manager>();
        private static List<Developer> developers = new List<Developer>();

        public static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=========================================== \nEMPLOYEE MANAGEMENT SYSTEM \n===========================================\n1. Add Manager \n2. Add Developer \n3. Display Managers \n4. Display Developers \n0. Exit \n===========================================");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddManager();
                        break;
                    case 2:
                        AddDeveloper();
                        break;
                    case 3:
                        DisplayManagers();
                        break;
                    case 4:
                        DisplayDevelopers();
                        break;
                    case 0:
                        Console.WriteLine("\n===========================================\nExiting Employee Management System...\n===========================================n");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\n===========================================\nInvalid option, please try again.\n===========================================n");
                        break;
                }
            }
        }

        private static void AddManager()
        {
            Console.WriteLine("\n===========================================\nAdding Manager...\n===========================================");
            Console.Write("Enter Manager's Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            managers.Add(new Manager { Name = name });
            Console.WriteLine("Manager added successfully.\n");
            Console.WriteLine("===========================================\n");
        }

        private static void AddDeveloper()
        {
            Console.WriteLine("\n===========================================\nAdding Developer...\n===========================================");
            Console.Write("Enter Developer's Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            developers.Add(new Developer { Name = name });
            Console.WriteLine("Developer added successfully.\n");
            Console.WriteLine("===========================================");
        }

        private static void DisplayManagers()
        {

            Console.WriteLine("\n===========================================\nManagers:\n===========================================");
            foreach (var manager in managers)
            {
                Console.WriteLine($"{manager.Name}. Salary = {manager.CalculateSalary():F2} INR.");
            }
            Console.WriteLine("===========================================");

        }

        private static void DisplayDevelopers()
        {
            Console.WriteLine("\n===========================================\nDevelopers:\n===========================================");
            foreach (var developer in developers)
            {
                Console.WriteLine($"{developer.Name}. Salary = {developer.CalculateSalary():F2} INR.");
            }
            Console.WriteLine("===========================================");
        }
    }
}
