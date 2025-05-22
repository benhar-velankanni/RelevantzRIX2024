using System.Text;

class Excercise
{
    static void Main()
    {
    Console.WriteLine("The vale 9999 in various formats:");
    Console.WriteLine("c format: {0:c}", 9999);
    Console.WriteLine("d9 format: {0:d9}", 9999);
    Console.WriteLine("f3 format: {0:f3}", 9999);
    Console.WriteLine("n format: {0:n}", 9999);
    Console.WriteLine("e format: {0:e}", 9999);
    Console.WriteLine("E format: {0:E}", 9999);
    Console.WriteLine("X format: {0:X}", 9999);
    Console.WriteLine("x format: {0:x}", 9999);
    int maxvalue = int.MaxValue;
    Console.WriteLine("maximumvalue:", maxvalue);
    Console.ReadLine();
    DateTime dt=new DateTime(2025,05,10);
    //(year,month,day)
    Console.WriteLine("The day of {0}, is {1}", dt.Date, dt.DayOfWeek);
    TimeSpan ts=new TimeSpan(9,30,20);
    //(hours,minutes,seconds)
    Console.WriteLine("Hours: {0} minutes: {1} seconds: {2}", ts.Hours, ts.Minutes, ts.Seconds);
    string firstname="Nithis";
    Console.WriteLine("Has {0} characters", firstname.Length);
    Console.WriteLine("Has uppercase {0} characters", firstname.ToUpper().Length);
    Console.WriteLine("Has lowercase {0} characters", firstname.ToLower().Length);
    string s1="2707";
    Console.WriteLine(s1);
    int result1=Convert.ToInt32(s1);
    Console.WriteLine(result1);
    bool success1;
    success1=int.TryParse(s1, out result1);
    Console.WriteLine(success1);
    string s2="2.707";
    Console.WriteLine(s2);
    int result2=Convert.ToInt32(s2);
    Console.WriteLine(result2);
    bool success;
    success=int.TryParse(s2, out result2);
    Console.WriteLine(success);
    string str="C# learning session using Visual Studio Code";
    Console.WriteLine("is Empty : "+string.IsNullOrWhiteSpace(str));
    Console.WriteLine("is Empty : "+string.IsNullOrEmpty(str));
    Random random=new Random();
    Console.WriteLine("Random number between 1 to 10 :"+random.Next(1,10));
    StringBuilder sb=new StringBuilder();
    Console.WriteLine(sb.Append("C# learning session using Visual Studio Code"));
    Console.WriteLine(sb.Replace("Visual Studio Code","VS Code"));

    }
}
