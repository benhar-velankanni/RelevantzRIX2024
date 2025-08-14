// Ex : 5	Calculator Class - this and Method Overloading
// Objective: Reinforce the use of this with method overloading.
// Instructions:
// Create a Calculator class with overloaded Add methods:
// Add(int a, int b)
// Add(int a, int b, int c)

using System;

public class Calculator
{
    // Overloaded Add methods
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return this.Add(a, b) + c;
    }
}

public class Program
{
    public static void Main()
    {
        Calculator calculator = new Calculator();

        // Calling Add methods
        int result1 = calculator.Add(2, 3);
        int result2 = calculator.Add(1, 4, 5);

        Console.WriteLine($"\nResult of Add(2, 3): {result1}");
        Console.WriteLine($"\nResult of Add(1, 4, 5): {result2}");
    }
}
