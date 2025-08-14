class Intern : Employee
{
    public string Designation { get; set; }
    public int Period { get; set; }

    public Intern(string desig, int period, int id, string name, string dept) : base(id, name, dept)
    {
        Designation = desig;
        Period = period;
    }

    public override void Display()
    {
        Console.WriteLine($"ID={Id}, Name={Name}, Dept={Dept}, Designation={Designation}, Period={Period}");
    }
}