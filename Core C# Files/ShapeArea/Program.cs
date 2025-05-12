namespace ShapeAreaCalculator
{
    public abstract class Shape
    {
        public abstract double GetArea();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public override double GetArea()
        {
            return Length * Width;
        }
    }

    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public override double GetArea()
        {
            return 0.5 * Base * Height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===========================================\nSHAPE AREA CALCULATOR \n===========================================");
                Console.WriteLine("1. Circle");
                Console.WriteLine("2. Rectangle");
                Console.WriteLine("3. Triangle");
                Console.WriteLine("0. Exit");
                Console.Write("Choose Option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                Shape shape = null;

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n===========================================\nCIRCLE \n===========================================");
                        Console.Write("Enter radius: ");
                        double radius = Convert.ToDouble(Console.ReadLine());
                        shape = new Circle { Radius = radius };
                        Console.WriteLine($"Area of {shape.GetType().Name}: {shape.GetArea():F2}");
                        Console.WriteLine("===========================================");
                        break;
                    case 2:
                        Console.WriteLine("\n===========================================\nRECTANGLE \n===========================================");
                        Console.Write("Enter length: ");
                        double length = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter width: ");
                        double width = Convert.ToDouble(Console.ReadLine());
                        shape = new Rectangle { Length = length, Width = width };
                        Console.WriteLine($"Area of {shape.GetType().Name}: {shape.GetArea():F2}");
                        Console.WriteLine("===========================================");
                        break;
                    case 3:
                        Console.WriteLine("\n===========================================\nTRIANGLE \n===========================================");
                        Console.Write("Enter base: ");
                        double @base = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter height: ");
                        double height = Convert.ToDouble(Console.ReadLine());
                        shape = new Triangle { Base = @base, Height = height };
                        Console.WriteLine($"Area of {shape.GetType().Name}: {shape.GetArea():F2}");
                        Console.WriteLine("===========================================");
                        break;
                    case 0:
                        Console.WriteLine("\n===========================================\nExiting Shape Area Calculator...\n===========================================");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }
            }
        }
    }
}

