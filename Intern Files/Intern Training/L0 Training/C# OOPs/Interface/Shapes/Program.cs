// // 3	Write a C# program to create an interface Shape with the getArea() method.
// Create three classes Rectangle, Circle, and Triangle that implement the Shape interface.
// Implement the getArea() method for each of the three classes.

class Program
{
    public static void Main()
    {
        Rectangle rectangle = new Rectangle();
        rectangle.getArea(2, 3);

        Circle circle= new Circle();
        circle.getArea(2.00);

        Square square= new Square();
        square.getArea(2);
    }
}