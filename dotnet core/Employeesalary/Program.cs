using System;

public class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    public Employee(string name, double baseSalary)
    {
        Name = name;
        BaseSalary = baseSalary;
    }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

public class Manager : Employee
{
    public double Bonus { get; set; }

    public Manager(string name, double baseSalary, double bonus) 
        : base(name, baseSalary)
    {
        Bonus = bonus;
    }

    public override double CalculateSalary()
    {
        return base.CalculateSalary() + Bonus;
    }
}

public class Developer : Employee
{
    public double OvertimeRate { get; set; }

    public Developer(string name, double baseSalary, double overtimeRate) 
        : base(name, baseSalary)
    {
        OvertimeRate = overtimeRate;
    }

    public override double CalculateSalary()
    {
        return base.CalculateSalary()+(base.CalculateSalary() * OvertimeRate);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the name of the manager: ");
        string managerName = Console.ReadLine();

        Console.Write("Enter the base salary of the manager: ");
        double managerBaseSalary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the bonus of the manager: ");
        double managerBonus = Convert.ToDouble(Console.ReadLine());

        var manager = new Manager(managerName, managerBaseSalary, managerBonus);

        Console.Write("Enter the name of the developer: ");
        string developerName = Console.ReadLine();

        Console.Write("Enter the base salary of the developer: ");
        double developerBaseSalary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the overtime rate of the developer: ");
        double developerOvertimeRate = Convert.ToDouble(Console.ReadLine());

        var developer = new Developer(developerName, developerBaseSalary, developerOvertimeRate);

        Console.WriteLine($"Manager's salary: {manager.CalculateSalary()}");
        Console.WriteLine($"Developer's salary: {developer.CalculateSalary()}");
    }
}