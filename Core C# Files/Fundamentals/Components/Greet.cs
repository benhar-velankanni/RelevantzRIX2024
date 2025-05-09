using System;

namespace Greet
{
    public class Program
    {
        public static void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=========================================== \nGREET BASED ON TIME \n===========================================\n1. Enter hour \n2. Exit \n===========================================");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                    checkpoint1:
                        Console.Write("\nEnter hour (0 to 23): ");
                        int hour = Convert.ToInt32(Console.ReadLine());

                        if (hour >= 0 && hour <= 11)
                        {
                            Console.WriteLine("Good Morning\n");
                        }
                        else if (hour >= 12 && hour <= 17)
                        {
                            Console.WriteLine("Good Afternoon\n");
                        }
                        else if (hour >= 18 && hour <= 23)
                        {
                            Console.WriteLine("Good Evening\n");
                        }
                        else
                        {
                            Console.WriteLine("Invalid hour\n");
                            goto checkpoint1;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Exiting Greeter...\n");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}

