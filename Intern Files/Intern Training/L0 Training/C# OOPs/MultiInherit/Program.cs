using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void DisplayPersonDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
    }
}

class Employee : Person
{
    public string EmployeeID { get; set; }
    public string Department { get; set; }

    public void DisplayEmployeeDetails()
    {
        DisplayPersonDetails();
        Console.WriteLine($"Employee ID: {EmployeeID}");
        Console.WriteLine($"Department: {Department}");
    }
}

class Manager : Employee
{
    public int TeamSize { get; set; }
    public double Bonus { get; set; }

    public void DisplayManagerDetails()
    {
        DisplayEmployeeDetails();
        Console.WriteLine($"Team Size: {TeamSize}");
        Console.WriteLine($"Bonus: {Bonus}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager();

        Console.WriteLine("Enter Manager Details:");

        Console.Write("Name: ");
        manager.Name = Console.ReadLine();

        Console.Write("Age: ");
        manager.Age = int.Parse(Console.ReadLine());

        Console.Write("Employee ID: ");
        manager.EmployeeID = Console.ReadLine();

        Console.Write("Department: ");
        manager.Department = Console.ReadLine();

        Console.Write("Team Size: ");
        manager.TeamSize = int.Parse(Console.ReadLine());

        Console.Write("Bonus: ");
        manager.Bonus = double.Parse(Console.ReadLine());

        manager.DisplayManagerDetails();
    }
}