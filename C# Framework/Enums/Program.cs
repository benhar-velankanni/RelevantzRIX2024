
using System;
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine((int)WeekDays.Sunday); //explict conversion from enum to int
        Console.WriteLine(WeekDays.Monday);
        Console.WriteLine(WeekDays.Tuesday);
        Console.WriteLine(WeekDays.Wednesday);
        Console.WriteLine(WeekDays.Thursday);
        Console.WriteLine(WeekDays.Friday);
        Console.WriteLine(WeekDays.Saturday);
    }
}