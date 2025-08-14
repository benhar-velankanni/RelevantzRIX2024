class SalesRep : Employee
{
    public int Quota { get; set; }
    public int YOExp { get; set; }

    public SalesRep(int quota, int yoExp, int id, string name, string dept) : base(id, name, dept)
    {
        Quota = quota;
        YOExp = yoExp;
    }

    public override void Display()
    {
        Console.WriteLine($"ID={Id}, Name={Name}, Dept={Dept}, Quota={Quota}, YOExp={YOExp}");
    }
}