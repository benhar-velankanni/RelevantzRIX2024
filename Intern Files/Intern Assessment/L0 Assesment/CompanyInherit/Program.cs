// Inheritance - Different Types of Employees 
// A company wants to implement a system for calculating employee bonuses. They have three types of employees: 
// Regular Employees: These employees receive a standard bonus based on their salary. 
// Managers: Managers receive a bonus that depends on their salary and the number of employees they directly manage (their direct reports). 
// Contractors: Contractors receive a bonus based on the number of hours they've worked and their hourly rate. 

// The company needs a flexible system that can handle all three types of employees consistently, even though the bonus calculation method is different for each. They also want to be able to easily add new employee types in the future without having to modify existing code too much. 
// Create a base class Employee 
// Add a virtual method. This method should return a double representing the bonus amount. 
// Create a derived class called Manager that inherits from Employee. 
// The manager's bonus should be calculated based on a formula that considers both their salary and the number of direct reports (e.g., bonus = salary * 0.10 + NumberOfDirectReports * 100).  
// Create a derived class called Contractor that inherits from Employee. The contractor's bonus should be calculated based on their hourly rate and the number of hours worked (e.g., bonus = HourlyRate * HoursWorked * 0.05). 
// Create a List<Employee> (a list that can hold Employee objects and objects of any type derived from Employee).  
// Add a mix of Employee, Manager, and Contractor objects to the list. Iterate through the list.  
// For each Employee object in the list, Calculate Bonus. Print the employee's details and their calculated bonus. 

class Company
{
    public List<Employee> employees = new List<Employee>();
    public List<Manager> managers = new List<Manager>();
    public List<Contractor> contractors = new List<Contractor>();

    public static void Main()
    {
        Company company = new Company();
        Employee employee = new Employee();
        Manager manager = new Manager();
        Contractor contractor = new Contractor();

    checkpoint1:
        Console.WriteLine("\nEmployee Record System: ");
        Console.WriteLine("1. Add Employee.");
        Console.WriteLine("2. Add Manager.");
        Console.WriteLine("3. Add Contractor.");
        Console.WriteLine("4. Remove Employee.");
        Console.WriteLine("5. Calculate Bonus.");
        Console.WriteLine("0. Exit.");

        Console.WriteLine("\nEnter your choice: ");
        int choice1 = int.Parse(Console.ReadLine());

        switch (choice1)
        {
            default:
                {
                    Console.WriteLine("\nINVALID CHOICE! TRY AGAIN!");
                    goto checkpoint1;
                }

            case 0:
                {
                    Console.WriteLine("\nLOGGING OUT...");
                    return;
                }

            case 1:
                {
                    employee.AddEmployee(company.employees);
                    goto checkpoint1;
                }

            case 2:
                {
                    manager.AddManager(company.managers);
                    goto checkpoint1;
                }

            case 3:
                {
                    contractor.AddContractor(company.contractors);
                    goto checkpoint1;
                }

            case 4:
                {
                    goto removal;
                }

            case 5:
                {
                    goto bonuses;
                }
        }

    removal:
        Console.WriteLine("\nChoose what to remove:");
        Console.WriteLine("1. Employee.");
        Console.WriteLine("2. Manager.");
        Console.WriteLine("3. Contractor.");
        Console.WriteLine("0. Back.");

        Console.WriteLine("\nEnter your choice: ");
        int choice2 = int.Parse(Console.ReadLine());

        switch (choice2)
        {
            default:
                {
                    Console.WriteLine("\nINVALID CHOICE! TRY AGAIN!");
                    goto removal;
                }

            case 0:
                {
                    goto checkpoint1;
                }

            case 1:
                {
                    employee.RemoveEmployee(company.employees);
                    goto checkpoint1;
                }

            case 2:
                {
                    manager.RemoveManager(company.managers);
                    goto checkpoint1;
                }

            case 3:
                {
                    contractor.RemoveContractor(company.contractors);
                    goto checkpoint1;
                }
        }

    bonuses:
        
        Console.WriteLine("\nChoose for whom to calculate:");
        Console.WriteLine("1. Employee.");
        Console.WriteLine("2. Manager.");
        Console.WriteLine("3. Contractor.");
        Console.WriteLine("0. Back.");

        Console.WriteLine("\nEnter your choice: ");
        int choice3 = int.Parse(Console.ReadLine());

        switch (choice3)
        {
            default:
                {
                    Console.WriteLine("\nINVALID CHOICE! TRY AGAIN!");
                    goto bonuses;
                }

            case 0:
                {
                    goto checkpoint1;
                }

            case 1:
                {
                    Console.WriteLine($"The bonus of the selected regular employee is {employee.BonusAmount(company.employees)}.");
                    goto checkpoint1;
                }

            case 2:
                {
                    Console.WriteLine($"The bonus of the selected  manager is {manager.BonusAmount(company.managers)}");
                    goto checkpoint1;
                }

            case 3:
                {
                    Console.WriteLine($"The bonus of the selected contractor is {contractor.BonusAmount(company.contractors)}");
                    goto checkpoint1;
                }
        }


    }
}