using System;

class TimeBasedGreeting
{
    static void Main()
    {
        Console.Write("Enter hour (0-23): ");
        int hour = Convert.ToInt32(Console.ReadLine());

        if (hour >= 0 && hour <= 11)
        {
            Console.WriteLine("Good Morning");
        }
        else if (hour >= 12 && hour <= 17)
        {
            Console.WriteLine("Good Afternoon");
        }
        else if (hour >= 18 && hour <= 23)
        {
            Console.WriteLine("Good Evening");
        }
        else
        {
            Console.WriteLine("Invalid hour");
        }
    }
}