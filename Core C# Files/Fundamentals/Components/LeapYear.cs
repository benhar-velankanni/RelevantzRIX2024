using System;

namespace LeapYearChecker
{
    public class Program
    {
        public static void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=========================================== \nLEAP YEAR CHECKER \n===========================================\n1. Enter year \n2. Exit \n===========================================");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter year: ");
                        int year = Convert.ToInt32(Console.ReadLine());

                        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                        {
                            Console.WriteLine($"{year} is a leap year.\n");
                        }
                        else
                        {
                            Console.WriteLine($"{year} is not a leap year.\n");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Exiting Checker...\n");
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

