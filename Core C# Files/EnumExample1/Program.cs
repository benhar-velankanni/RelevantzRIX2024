public enum Weekday
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public class Days
{
    public static void DoSomething(Weekday day)
    {
        switch (day)
        {
            case Weekday.Monday:
                Console.WriteLine("Today is Monday");
                break;
            case Weekday.Tuesday:
                Console.WriteLine("Today is Tuesday");
                break;
            case Weekday.Wednesday:
                Console.WriteLine("Today is Wednesday");
                break;
            case Weekday.Thursday:
                Console.WriteLine("Today is Thursday");
                break;
            case Weekday.Friday:
                Console.WriteLine("Today is Friday");
                break;
            case Weekday.Saturday:
                Console.WriteLine("Today is Saturday");
                break;
            case Weekday.Sunday:
                Console.WriteLine("Today is Sunday");
                break;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Weekday today = DateTime.Today.DayOfWeek switch
        {
            DayOfWeek.Monday => Weekday.Monday,
            DayOfWeek.Tuesday => Weekday.Tuesday,
            DayOfWeek.Wednesday => Weekday.Wednesday,
            DayOfWeek.Thursday => Weekday.Thursday,
            DayOfWeek.Friday => Weekday.Friday,
            DayOfWeek.Saturday => Weekday.Saturday,
            DayOfWeek.Sunday => Weekday.Sunday,
            _ => throw new ArgumentOutOfRangeException()
        };
        Days.DoSomething(today);
    }
}