//Ex : 6	C# Inheritance program (Shape, Rectangle,quadrilateral, Square, Circle )

using System;

class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("\nDrawing a shape.");
        Console.WriteLine("====================================");
    }

    public virtual double Area()
    {
        return 0;
    }

    public virtual double Perimeter()
    {
        return 0;
    }
}

class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override void Draw()
    {
        Console.WriteLine("\nDrawing a rectangle.");
        Console.WriteLine("====================================");
    }

    public override double Area()
    {
        return Length * Width;
    }

    public override double Perimeter()
    {
        return 2 * (Length + Width);
    }
}

class Quadrilateral : Shape
{
    public double Side1 { get; set; }
    public double Side2 { get; set; }
    public double Side3 { get; set; }
    public double Side4 { get; set; }

    public Quadrilateral(double side1, double side2, double side3, double side4)
    {
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
        Side4 = side4;
    }

    public override void Draw()
    {
        Console.WriteLine("\nDrawing a quadrilateral.");
        Console.WriteLine("====================================");
    }

    public override double Perimeter()
    {
        return Side1 + Side2 + Side3 + Side4;
    }
}

class Square : Rectangle
{
    public Square(double side) : base(side, side)
    {
    }

    public override void Draw()
    {
        Console.WriteLine("\nDrawing a square.");
        Console.WriteLine("====================================");
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine("\nDrawing a circle.");
        Console.WriteLine("====================================");
    }

    public override double Area()
    {
        return 3.14 * Radius * Radius;
    }

    public override double Perimeter()
    {
        return 2 * 3.14 * Radius;
    }
}

class Program
{
    static void Main()
    {
    start:
        Console.WriteLine("\nShapes and Stuff: ");
        Console.WriteLine("====================================");
        Console.WriteLine("1. Rectangle.");
        Console.WriteLine("2. Quadrilateral.");
        Console.WriteLine("3. Square.");
        Console.WriteLine("4. Circle");
        Console.WriteLine("0. Exit.");
        Console.Write("\nEner your choice: ");
        int choice1 = int.Parse(Console.ReadLine());

        switch (choice1)
        {
            case 0:
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("Loging Out!");
                    Console.WriteLine("====================================");
                    return;
                }

            case 1:
                {
                    goto Rectangle;
                }

            case 2:
                {
                    goto Quadrilateral;
                }

            case 3:
                {
                    goto Square;
                }

            case 4:
                {
                    goto Circle;
                }

            default:
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine("Invalid Choice!");
                    Console.WriteLine("====================================");
                    goto start;
                }
        }

    Rectangle:

        Console.WriteLine("\nEnter the dimensions of the rectangle: ");
        Console.WriteLine("====================================");
        Console.Write("Length: ");
        int len = int.Parse(Console.ReadLine());
        Console.Write("Breadth: ");
        int breadth = int.Parse(Console.ReadLine());

        Rectangle rectangle = new Rectangle(len, breadth);

        rectangle.Draw();
        Console.WriteLine($"Rectangle Area: {rectangle.Area()}");
        Console.WriteLine($"Rectangle Perimeter: {rectangle.Perimeter()}");

        goto start;

    Quadrilateral:

        Console.WriteLine("\nEnter the dimensions of the quadrilateral: ");
        Console.WriteLine("====================================");
        Console.Write("Side 1: ");
        int side1 = int.Parse(Console.ReadLine());
        Console.Write("Side 2: ");
        int side2 = int.Parse(Console.ReadLine());
        Console.Write("Side 3: ");
        int side3 = int.Parse(Console.ReadLine());
        Console.Write("Side 4: ");
        int side4 = int.Parse(Console.ReadLine());

        Quadrilateral quadrilateral = new Quadrilateral(side1, side2, side3, side4);

        quadrilateral.Draw();
        Console.WriteLine($"Quadrilateral Perimeter: {quadrilateral.Perimeter()}");

        goto start;

    Square:

        Console.WriteLine("\nEnter the dimensions of the square: ");
        Console.WriteLine("====================================");
        Console.Write("Side: ");
        int squareSide = int.Parse(Console.ReadLine());

        Square square = new Square(squareSide);

        square.Draw();
        Console.WriteLine($"Square Area: {square.Area()}");
        Console.WriteLine($"Square Perimeter: {square.Perimeter()}");

        goto start;

    Circle:

        Console.WriteLine("\nEnter the dimensions of the circle: ");
        Console.WriteLine("====================================");
        Console.Write("Radius: ");
        int radius = int.Parse(Console.ReadLine());

        Circle circle = new Circle(radius);

        circle.Draw();
        Console.WriteLine($"Circle Area: {circle.Area()}");
        Console.WriteLine($"Circle Perimeter: {circle.Perimeter()}");

        goto start;
    }
}
