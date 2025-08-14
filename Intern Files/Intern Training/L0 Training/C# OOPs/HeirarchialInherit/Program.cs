using System;
 
class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string EmployeeID { get; set; }
 
    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Employee ID: {EmployeeID}");
    }
}
 
class Manager : Employee
{
    public int TeamSize { get; set; }
 
    public void DisplayManagerDetails()
    {
        DisplayEmployeeDetails();
        Console.WriteLine($"Team Size: {TeamSize}");
    }
}
 
class Developer : Employee
{
    public string ProgrammingLanguage { get; set; }
 
    public void DisplayDeveloperDetails()
    {
        DisplayEmployeeDetails();
        Console.WriteLine($"Programming Language: {ProgrammingLanguage}");
    }
}
 
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose the type of employee: 1. Manager 2. Developer");
        int choice = int.Parse(Console.ReadLine());
 
        if (choice == 1)
        {
            Manager manager = new Manager();
 
            Console.WriteLine("Enter Manager Details:");
            Console.Write("Name: ");
            manager.Name = Console.ReadLine();
            Console.Write("Age: ");
            manager.Age = int.Parse(Console.ReadLine());
            Console.Write("Employee ID: ");
            manager.EmployeeID = Console.ReadLine();
            Console.Write("Team Size: ");
            manager.TeamSize = int.Parse(Console.ReadLine());
 
            manager.DisplayManagerDetails();
        }
        else if (choice == 2)
        {
            Developer developer = new Developer();
 
            Console.WriteLine("Enter Developer Details:");
            Console.Write("Name: ");
            developer.Name = Console.ReadLine();
            Console.Write("Age: ");
            developer.Age = int.Parse(Console.ReadLine());
            Console.Write("Employee ID: ");
            developer.EmployeeID = Console.ReadLine();
            Console.Write("Programming Language: ");
            developer.ProgrammingLanguage = Console.ReadLine();
 
            developer.DisplayDeveloperDetails();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please restart the program and choose a valid option.");
        }
    }
}