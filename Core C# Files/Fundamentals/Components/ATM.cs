using System;

namespace ATM
{
    public class Program
    {
        public static void Run()
        {
            bool exit = false;
            int balance = 10000;

            while (!exit)
            {
                Console.WriteLine($"\n=========================================== \nATM MACHINE \n=========================================== \nCurrent Balance: {balance} \n===========================================\n1. Enter withdrawal amount \n2. Exit \n===========================================");
                Console.Write("Select an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter withdrawal amount: ");
                        int withdrawAmount = Convert.ToInt32(Console.ReadLine());

                        if (withdrawAmount <= balance)
                        {
                            balance -= withdrawAmount;
                            Console.WriteLine("Withdrawal successful\n");
                            Console.WriteLine($"Current balance: {balance}\n");

                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance\n");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Exiting ATM...\n");
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

