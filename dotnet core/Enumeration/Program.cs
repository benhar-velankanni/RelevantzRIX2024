using System;
 
namespace Enumerate
{

    enum WeekDays {
        Sunday = 10,
        Monday,
        Tuesday,
        Wednesday,
        Thursday
    }
    enum WeekDays1 {
        Friday,
        Saturday
    }
    class Program
    {
        static void Main(string[] args)
        {

            WeekDays day = WeekDays.Monday;
            Console.WriteLine(day);
            WeekDays1 day1 = WeekDays1.Friday;
            Console.WriteLine(day1);
        }
    }
}