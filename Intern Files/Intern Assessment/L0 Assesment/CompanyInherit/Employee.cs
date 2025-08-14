class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
    public double Bonus = 10.00;

    public Employee(int id, string name, double salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    public Employee()
    {
        return;
    }

    public double BonusAmount(List<Employee> employees)
    {
        Console.WriteLine("\nEnter the ID:");
        int id = int.Parse(Console.ReadLine());

        Employee employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return 0.00;
        }
        else
        {
            return employee.Salary * employee.Bonus * 0.10;
        }
    }

    public void AddEmployee(List<Employee> employees)
    {
        Console.WriteLine("\nEnter the Employee Details: ");
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Salary: ");
        double salary = double.Parse(Console.ReadLine());

        Employee employee = new Employee(id, name, salary);
        employees.Add(employee);
    }

    public virtual void RemoveEmployee(List<Employee> employees)
    {
        Console.Write("\nEnter the ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        Employee employeeToRemove = employees.Find(x => x.Id == id);
        if (employeeToRemove != null)
        {
            employees.Remove(employeeToRemove);
            Console.WriteLine($"\nThe employee of ID {id} removed successfully.");
        }
        else
        {
            Console.WriteLine($"\nThe employee of ID {id} does not exist.");
        }
    }
}