class Program
{
    delegate int MathOperation(int x, int y);

    static void Main()
    {
        MathOperation add = delegate (int x, int y)
        {
            Console.WriteLine("Addition:");
            return x + y;
        };
        MathOperation subtract = (x, y) => x - y;

        Console.WriteLine(add(10, 5)); // Outputs 15
        Console.WriteLine("Subtraction:");
        Console.WriteLine(subtract(10, 5)); // Outputs 5
    }
}
