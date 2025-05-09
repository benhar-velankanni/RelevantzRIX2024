using System;

namespace TrafficLightSystem
{
    public class Program
    {
        public static void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=========================================== \nTRAFFIC LIGHT SYSTEM  \n===========================================\n1. Enter light color \n2. Exit \n===========================================");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                    checkpoint1:
                        Console.Write("\nEnter light color (Red, Yellow, Green): ");
                        string? lightColor = Console.ReadLine()?.Trim().ToLower();

                        switch (lightColor)
                        {
                            case "red":
                                Console.WriteLine("Stop.\n");
                                break;
                            case "yellow":
                                Console.WriteLine("Ready.\n");
                                break;
                            case "green":
                                Console.WriteLine("Go.\n");
                                break;
                            default:
                                Console.WriteLine("Invalid input.\n");
                                goto checkpoint1;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Exiting Traffic Light System...\n");
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

