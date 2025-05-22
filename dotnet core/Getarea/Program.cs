using System;

public class Shape
{
    public virtual double GetArea()
    {
        return 0;
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

public class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override double GetArea()
    {
        return Length * Width;
    }
}

public class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double baseValue, double height)
    {
        Base = baseValue;
        Height = height;
    }

    public override double GetArea()
    {
        return 0.5 * Base * Height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the radius of the circle: ");
        double circleRadius = Convert.ToDouble(Console.ReadLine());

        var circle = new Circle(circleRadius);

        Console.Write("Enter the length of the rectangle: ");
        double rectangleLength = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the width of the rectangle: ");
        double rectangleWidth = Convert.ToDouble(Console.ReadLine());

        var rectangle = new Rectangle(rectangleLength, rectangleWidth);

        Console.Write("Enter the base of the triangle: ");
        double triangleBase = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the height of the triangle: ");
        double triangleHeight = Convert.ToDouble(Console.ReadLine());

        var triangle = new Triangle(triangleBase, triangleHeight);

        Console.WriteLine($"Circle area: {circle.GetArea()}");
        Console.WriteLine($"Rectangle area: {rectangle.GetArea()}");
        Console.WriteLine($"Triangle area: {triangle.GetArea()}");
    }
}