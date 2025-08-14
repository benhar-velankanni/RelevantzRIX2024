class Manager : Employee
{
    public string Designation { get; set; }
    public int YOExp { get; set; }

    public Manager(string desig, int yoExp, int id, string name, string dept) : base(id, name, dept)
    {
        Designation = desig;
        YOExp = yoExp;
    }
    
    public override void Display()
    {
        Console.WriteLine($"ID={Id}, Name={Name}, Dept={Dept}, Designation={Designation}, YOExp={YOExp}");
    }
}