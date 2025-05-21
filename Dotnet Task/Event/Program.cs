using System;
using EventApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Event Management System");
        while (true)
        {
            Console.WriteLine("1.Add Event");
            Console.WriteLine("2.View Event");
            Console.WriteLine("3.Search Event");
            Console.WriteLine("4.Update Event");
            Console.WriteLine("5.Delete Event");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Eventmanagement.AddEvent();
                    break;
                case 2:
                    Eventmanagement.ViewEvent();
                    break;
                case 3:
                    Eventmanagement.SearchEvent();
                    break;
                case 4:
                    Eventmanagement.UpdateEvent();
                    break;
                case 5:
                    Eventmanagement.DeleteEvent();
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