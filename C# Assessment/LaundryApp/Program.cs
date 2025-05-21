using System;
using LaundryApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the laundry app");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Please select an option");

        while (true)
        {
            Console.WriteLine("1.Add Items");
            Console.WriteLine("2.View Items");
            Console.WriteLine("3.Search Items");
            Console.WriteLine("4.Update Items");
            Console.WriteLine("5.Delete Items");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    LaundryApp.LaundryApp.AddItems();
                    break;
                case 2:
                    LaundryApp.LaundryApp.ViewItems();
                    break;
                case 3:
                    LaundryApp.LaundryApp.SearchItems();
                    break;
                case 4:
                    LaundryApp.LaundryApp.UpdateItems();
                    break;
                case 5:
                    LaundryApp.LaundryApp.DeleteItems();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}