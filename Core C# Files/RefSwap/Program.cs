namespace RefSwap
{
    class Program
    {
        static void Main(string[] args)
        {
        checkpoint1:
            Console.WriteLine("\n===========================\nWelcome to RefSwap! \n===========================");

            Console.Write("Enter a value for a: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a value for b: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n===========================\nBefore swap:");
            Console.WriteLine($"a = {a}, b = {b} \n===========================");

            Swap(ref a, ref b);

            Console.WriteLine("\n===========================\nAfter swap:");
            Console.WriteLine($"a = {a}, b = {b} \n===========================\n");

            Console.WriteLine("Wish to continue for another pair? [Y/N]");
            string? choice = Console.ReadLine()?.ToLower();
            if (choice == "y")
            {
                goto checkpoint1;
            }
            else if (choice == "n")
            {
                Console.WriteLine("Exiting...");
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Exiting...");
            }
        }

        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}

