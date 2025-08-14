class Circle : IShape
{
    public void getArea(double radius)
    {
        double result = 3.14 * radius * radius;
        Console.WriteLine("\nThe area of the circle is: " + result);
    }

    public void getArea(int len, int breadth)
    {
        return;
    }

    public void getArea(int side1)
    {
        return;
    }


}