namespace Patterns
{
    public class Program
    {
        public static void Run()
        {

            Console.WriteLine("\n=========================================== \nPATTERNS \n===========================================\nEnter number of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            // Pattern 8
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            for (int i = rows - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

            // Pattern 9
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            for (int i = rows - 2; i >= 0; i--)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nExiting Patterns...\n");
        }
    }
}
