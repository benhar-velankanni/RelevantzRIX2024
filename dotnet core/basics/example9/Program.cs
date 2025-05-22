using System;
class Pattern{
  static void Main(){
            Console.Write("Enter number of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            int n = rows / 2;
 
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j < n - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < 2 * i + 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < n - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < 2 * i + 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
}
