using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor for Person class
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
        Console.WriteLine("Person constructor called.");
    }

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

    // Constructor for Employee class
    public Employee(string name, int age, string employeeID, string department)
        : base(name, age)
    {
        EmployeeID = employeeID;
        Department = department;
        Console.WriteLine("Employee constructor called.");
    }

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

    // Constructor for Manager class
    public Manager(string name, int age, string employeeID, string department, int teamSize, double bonus)
        : base(name, age, employeeID, department)
    {
        TeamSize = teamSize;
        Bonus = bonus;
        Console.WriteLine("Manager constructor called.");
    }

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
        Console.WriteLine("Enter Manager Details:");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Employee ID: ");
        string employeeID = Console.ReadLine();

        Console.Write("Department: ");
        string department = Console.ReadLine();

        Console.Write("Team Size: ");
        int teamSize = int.Parse(Console.ReadLine());

        Console.Write("Bonus: ");
        double bonus = double.Parse(Console.ReadLine());

        Manager manager = new Manager(name, age, employeeID, department, teamSize, bonus);
        manager.DisplayManagerDetails();
    }
}