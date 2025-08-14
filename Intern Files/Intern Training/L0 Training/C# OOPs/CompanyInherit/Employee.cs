class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Dept { get; set; }

    public Employee(int id, string name, string dept)
    {
        Id = id;
        Name = name;
        Dept = dept;
    }

    public virtual void Display()
    {
        Console.WriteLine($"ID={Id}, Name={Name}, Dept={Dept}");
    }
}