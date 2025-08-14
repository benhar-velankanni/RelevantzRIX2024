//Ex : 5	C# Inheritance program (Employee, Manager, SalesRepresentative, Intern  )

class Company
{
    public static List<Employee> employees = new List<Employee>();
    public static List<Manager> managers = new List<Manager>();
    public static List<SalesRep> salesReps = new List<SalesRep>();
    public static List<Intern> interns = new List<Intern>();

    public static void AddEmployee(Employee employee)
    {
        employees.Add(employee);
        if (employee is Manager manager)
            managers.Add(manager);
        else if (employee is SalesRep salesRep)
            salesReps.Add(salesRep);
        else if (employee is Intern intern)
            interns.Add(intern);
    }

    public static void RemoveEmployeeById(int id)
    {
        var employeeToRemove = employees.FirstOrDefault(e => e.Id == id);
        if (employeeToRemove != null)
        {
            
            employees.Remove(employeeToRemove);

            if (employeeToRemove is Manager manager)
                managers.Remove(manager);
            else if (employeeToRemove is SalesRep salesRep)
                salesReps.Remove(salesRep);
            else if (employeeToRemove is Intern intern)
                interns.Remove(intern);

            Console.WriteLine($"\nEmployee with ID {id} removed successfully.");
        }
        else
        {
            Console.WriteLine($"\nEmployee with ID {id} not found.");
        }
    }

    public static void Main()
    {
    start:
        Console.WriteLine("\nEmployee Record System: ");
        Console.WriteLine("====================================");
        Console.WriteLine("1. Add a Manager.");
        Console.WriteLine("2. Add a Sales Reps.");
        Console.WriteLine("3. Add an Intern.");
        Console.WriteLine("4. Display All Employees.");
        Console.WriteLine("5. Display All Managers.");
        Console.WriteLine("6. Display All Sales Reps.");
        Console.WriteLine("7. Display All Interns.");
        Console.WriteLine("8. Remove An Employee.");
        Console.WriteLine("0. Exit.");
        Console.WriteLine("====================================");
        Console.Write("\nEnter your choice: ");
        int choice1 = int.Parse(Console.ReadLine());

        switch (choice1)
        {
            case 0:
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("Loging Out!");
                    Console.WriteLine("====================================");
                    return;
                }

            case 1:
                {
                    goto insertManager;
                }

            case 2:
                {
                    goto insertSalesRep;
                }

            case 3:
                {
                    goto insertIntern;
                }

            case 4:
                {
                    goto displayEmp;
                }

            case 5:
                {
                    goto displayManager;
                }

            case 6:
                {
                    goto displaySalesRep;
                }

            case 7:
                {
                    goto displayIntern;
                }

            case 8:
                {
                    goto removal;
                }

            default:
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("Invalid Choice!");
                    Console.WriteLine("====================================");
                    goto start;
                }

        }

    insertManager:

        Console.Write("\nEnter the number of Managers: ");
        int n1 = int.Parse(Console.ReadLine());
        Console.WriteLine("\nEnter details for Managers:");
        Console.WriteLine("====================================");
        for (int i = 0; i < n1; i++)
        {
            Console.Write("\nEnter ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Dept: ");
            string dept = Console.ReadLine();
            Console.Write("Enter Designation: ");
            string designation = Console.ReadLine();
            Console.Write("Enter YOExp: ");
            int YOExp = int.Parse(Console.ReadLine());

            AddEmployee(new Manager(designation, YOExp, id, name, dept));
        }

        goto start;

    insertSalesRep:

        Console.Write("\nEnter the number of Sales Representatives: ");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine("\nEnter details for Sales Representatives:");
        Console.WriteLine("====================================");
        for (int i = 0; i < n2; i++)
        {
            Console.Write("\nEnter ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Dept: ");
            string dept = Console.ReadLine();
            Console.Write("Enter Quota: ");
            int quota = int.Parse(Console.ReadLine());
            Console.Write("Enter YOExp: ");
            int YOExp = int.Parse(Console.ReadLine());

            AddEmployee(new SalesRep(quota, YOExp, id, name, dept));
        }

        goto start;

    insertIntern:

        Console.Write("\nEnter the number of Interns: ");
        int n3 = int.Parse(Console.ReadLine());
        Console.WriteLine("\nEnter details for Interns:");
        Console.WriteLine("====================================");
        for (int i = 0; i < n3; i++)
        {
            Console.Write("\nEnter ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Dept: ");
            string dept = Console.ReadLine();
            Console.Write("Enter Designation: ");
            string designation = Console.ReadLine();
            Console.Write("Enter Period: ");
            int period = int.Parse(Console.ReadLine());

            AddEmployee(new Intern(designation, period, id, name, dept));
        }

        goto start;

    displayEmp:

        // Displaying details of all employees.
        Console.WriteLine("\n====================================");
        Console.WriteLine("Employees List:");
        Console.WriteLine("====================================");
        foreach (var employee in employees)
        {
            employee.Display();
        }

        goto start;

    displayManager:

        // Displaying details of all managers.
        Console.WriteLine("\n====================================");
        Console.WriteLine("Managers:");
        Console.WriteLine("====================================");
        foreach (var manager in managers)
        {
            manager.Display();
        }

        goto start;

    displaySalesRep:

        // Displaying details of all sales rep.
        Console.WriteLine("\n====================================");
        Console.WriteLine("Sales Representatives:");
        Console.WriteLine("====================================");
        foreach (var salesRep in salesReps)
        {
            salesRep.Display();
        }

        goto start;

    displayIntern:

        // Displaying details of all interns.
        Console.WriteLine("\n====================================");
        Console.WriteLine("Interns:");
        Console.WriteLine("====================================");
        foreach (var intern in interns)
        {
            intern.Display();
        }

        goto start;

    removal:

        // Removing an employee by ID.
        Console.Write("\nEnter ID of the employee to remove: ");
        int idToRemove = int.Parse(Console.ReadLine());
        RemoveEmployeeById(idToRemove);

        goto start;
    }
}