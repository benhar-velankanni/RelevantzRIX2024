class Rectangle : Shape
{
    public override  void GetArea(int len, int breadth)
    {
        int result = len * breadth;
        Console.WriteLine("The area of the rectangle is: " + result);
    }

    public override  void GetPerimeter(int len, int breadth)
    {
        int result = 2 * len * breadth;
        Console.WriteLine("The perimeter of the rectangle is: " + result);
    }

    public override void GetArea(double radius)
    {
        return;
    }

    public override void GetPerimeter(double radius)
    {
        return;
    }

    public override void GetPerimeter(int side1, int side2, int side3){}

    public override void GetArea(int side1, int side2, int side3)
    {
        return;
    }
}