using System;
 
namespace Delegates
{
    class Program
    {
        delegate int BinaryOp(int x, int y);
 
        static void Main(string[] args)
        {
            Console.WriteLine("Demonstrating delegates");
 
            // Create two delegates
            BinaryOp add = (int x, int y) => x + y;
            BinaryOp multiply = (int x, int y) => x * y;
 
            Console.WriteLine("Using add delegate:");
            Console.WriteLine($"3 + 4 = {add(3, 4)}");
 
            Console.WriteLine("Using multiply delegate:");
            Console.WriteLine($"3 * 4 = {multiply(3, 4)}");
 
            Console.WriteLine("Using delegate with foreach:");
            foreach (var op in new BinaryOp[] { add, multiply })
            {
                Console.WriteLine($"3 {op.Method.Name} 4 = {op(3, 4)}");
            }
        }
    }
}
 
 