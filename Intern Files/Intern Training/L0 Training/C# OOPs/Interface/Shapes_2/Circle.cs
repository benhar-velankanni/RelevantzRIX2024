class Circle : Shape
{
    public override void GetArea(double radius)
    {
        double result = 3.14 * radius * radius;
        Console.WriteLine("The area of the circle is: " + result);
    }

    public override  void GetPerimeter(double radius)
    {
        double result = 3.14 * 2 * radius;
        Console.WriteLine("The perimeter of the circle is: " + result);
    }

    public override void GetArea(int len, int breadth)
    {
        return;
    }

    public override void GetPerimeter(int len, int breadth)
    {
        return;
    }

    public override void GetArea(int side1, int side2, int side3)
    {
        return;
    }
    
    public override void GetPerimeter(int side1, int side2, int side3)
    {
        return;
    }
}