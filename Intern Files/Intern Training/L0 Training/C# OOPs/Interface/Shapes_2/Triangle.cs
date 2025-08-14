class Triangle : Shape
{
    public override  void GetArea(int side1, int side2, int side3)
    {
        float result = (float) 0.5 * side1 * side2;
        Console.WriteLine("The area of the triangle is: " + result);
    }

    public override  void GetPerimeter(int side1, int side2, int side3)
    {
        int result = side1 + side2 + side3;
        Console.WriteLine("The perimeter of the triangle is: " + result);
    }

    public override  void GetArea(double radius)
    {
        return;
    }

    public override  void GetArea(int len, int breadth)
    {
        return;
    }

    public override  void GetPerimeter(double radius)
    {
        return;
    }

    public override  void GetPerimeter(int len, int breadth)
    {
        return;
    }
}