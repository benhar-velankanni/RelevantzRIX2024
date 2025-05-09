using System;

namespace Discount
{
    public class Program
    {
        public static void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=========================================== \nDISCOUNT CALCULATOR \n===========================================\n1. Enter total amount \n2. Exit \n===========================================");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter total amount: ");
                        double totalAmount = Convert.ToDouble(Console.ReadLine());

                        double discount = 0;

                        if (totalAmount > 5000)
                        {
                            discount = totalAmount * 0.2;
                        }
                        else if (totalAmount > 2000)
                        {
                            discount = totalAmount * 0.1;
                        }
                        Console.WriteLine($"Apply discount: {discount}\n");
                        break;
                    case 2:
                        Console.WriteLine("Exiting Discount Calculator...\n");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.\n");
                        break;
                }
            }
        }
    }
}

