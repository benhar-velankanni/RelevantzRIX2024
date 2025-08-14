class Contractor : Employee
{
    public double HourlyRate { get; set; }
    public double HoursWorked { get; set; }

    public Contractor(int id, string name, double salary, double hourlyRate, double hoursWorked) : base(id, name, salary)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public Contractor(){
        return;
    }

    public double BonusAmount(List<Contractor> contractors)
    {
        Console.WriteLine("\nEnter the ID:");
        int id = int.Parse(Console.ReadLine());

        Contractor contractor = contractors.FirstOrDefault(e => e.Id == id);
        if (contractor == null)
        {
            return 0.00;
        }
        else
        {
            return contractor.HourlyRate * contractor.HoursWorked * 0.05;
        }
    }

    public void AddContractor(List<Contractor> contractors)
    {
        Console.WriteLine("\nEnter the Contractor Details: ");
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Salary: ");
        double salary = double.Parse(Console.ReadLine());
        Console.Write("Hourly Rate: ");
        double hourlyRate = double.Parse(Console.ReadLine());
        Console.Write("Hours Worked: ");
        double hoursWorked = double.Parse(Console.ReadLine());

        Contractor contractor= new Contractor(id, name, salary, hourlyRate, hoursWorked); 
        contractors.Add(contractor);
    }

    public virtual void RemoveContractor(List<Contractor> Contractors)
    {
        Console.Write("\nEnter the ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        Contractor ContractorToRemove = Contractors.Find(x => x.Id == id);
        if (ContractorToRemove != null)
        {
            Contractors.Remove(ContractorToRemove);
            Console.WriteLine($"\nThe Contractor of ID {id} removed successfully.");
        }
        else
        {
            Console.WriteLine($"\nThe Contractor of ID {id} does not exist.");
        }
    }
}