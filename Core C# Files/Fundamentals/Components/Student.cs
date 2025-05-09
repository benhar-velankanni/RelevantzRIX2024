using System;

namespace StudentGradingSystem
{
    public class Program
    {
        public static void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=========================================== \nSTUDENT GRADING SYSTEM \n===========================================\n1. Enter marks \n2. Exit \n===========================================");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                    checkpoint1:
                        Console.Write("\nEnter marks: ");
                        int marks = Convert.ToInt32(Console.ReadLine());

                        if (marks >= 90 && marks <= 100)
                        {
                            Console.WriteLine("Grade A.\n");
                        }
                        else if (marks >= 75 && marks < 90)
                        {
                            Console.WriteLine("Grade B.\n");
                        }
                        else if (marks >= 50 && marks < 75)
                        {
                            Console.WriteLine("Grade C.\n");
                        }
                        else if (marks > 100)
                        {
                            Console.WriteLine("Invalid marks.\n");
                            goto checkpoint1;
                        }
                        else
                        {
                            Console.WriteLine("Fail.\n");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Exiting Grader...\n");
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
