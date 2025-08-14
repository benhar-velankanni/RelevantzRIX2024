abstract class Shape
{
    public abstract void GetArea(int len, int breadth);

    public abstract void GetArea(int side1, int side2, int side3);
    
    public abstract void GetArea(double radius);

    public abstract void GetPerimeter(int len, int breadth);

    public abstract void GetPerimeter(int side1, int side2, int side3);

    public abstract void GetPerimeter(double radius);
}