class Rectangle : IShape
{
    public void getArea(int len, int breadth)
    {
        int result = len * breadth;
        Console.WriteLine("\nThe area of the rectangle is: " + result);
    }

    public void getArea(int side1){
        return;
    }

    public void getArea(double radius){
        return;
    }
}