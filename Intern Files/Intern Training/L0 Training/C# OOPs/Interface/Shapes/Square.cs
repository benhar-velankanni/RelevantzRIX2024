class Square : IShape
{
    public void getArea(int side1)
    {
        int result = side1 * side1;
        Console.WriteLine("\nThe area of the square is: " + result);
    }

    public void getArea(double radius)
    {
        return;
    }

    public void getArea(int len, int breadth)
    {
        return;
    }
}