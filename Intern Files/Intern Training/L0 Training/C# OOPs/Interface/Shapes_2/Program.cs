//2	Write a C# program to create an abstract class Shape with abstract methods calculateArea() and calculatePerimeter().
//Create subclasses Circle and Triangle that extend the Shape class and implement the respective methods to
//calculate the area and perimeter of each shape.

class Program
{
    public static void Main()
    {
        Rectangle rectangle = new Rectangle();
        Console.WriteLine("====================================");
        rectangle.GetArea(2, 3);
        rectangle.GetPerimeter(2, 3);

        Circle circle= new Circle();
        Console.WriteLine("====================================");
        circle.GetArea(2.00);
        circle.GetPerimeter(2.00);

        Triangle triangle= new Triangle();
        Console.WriteLine("====================================");
        triangle.GetArea(2,2,2);
        triangle.GetPerimeter(2,2,2);
        Console.WriteLine("====================================");
    }
}