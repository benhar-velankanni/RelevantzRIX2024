class Manager : Employee
{
    public int NumberOfDirectReports { get; set; }

    public Manager(int id, string name, double salary, int numberOfDirectReports) : base(id, name, salary)
    {
        NumberOfDirectReports = numberOfDirectReports;
    }

    public Manager(){
        return;
    }

    public double BonusAmount(List<Manager> managers)
    {
        Console.WriteLine("\nEnter the ID:");
        int id = int.Parse(Console.ReadLine());

        Manager manager = managers.FirstOrDefault(e => e.Id == id);
        if (manager == null)
        {
            return 0.00;
        }
        else
        {
            return manager.Salary * 0.10 + manager.NumberOfDirectReports * 100;
        }
    }

    public void AddManager(List<Manager> managers)
    {
        Console.WriteLine("\nEnter the Manager Details: ");
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Salary: ");
        double salary = double.Parse(Console.ReadLine());
        Console.Write("Number of direct reports: ");
        int numberOfDirectReports = int.Parse(Console.ReadLine());

        Manager manager = new Manager(id, name, salary, numberOfDirectReports);
        managers.Add(manager);
    }

    public virtual void RemoveManager(List<Manager> managers)
    {
        Console.Write("\nEnter the ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        Manager ManagerToRemove = managers.Find(x => x.Id == id);
        if (ManagerToRemove != null)
        {
            managers.Remove(ManagerToRemove);
            Console.WriteLine($"\nThe Manager of ID {id} removed successfully.");
        }
        else
        {
            Console.WriteLine($"\nThe Manager of ID {id} does not exist.");
        }
    }
}