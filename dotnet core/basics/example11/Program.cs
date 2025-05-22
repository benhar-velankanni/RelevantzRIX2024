using System.Runtime.CompilerServices;
using System.Text;
class Example
{
    static void Main(string[] args)
    {
     
     
    string s3="Nithis";
    string s4="Bangaru";
    string s5=string.Concat(s3,s4);
    Console.WriteLine(s5);
    string s6=string.Join(" ",s3,s4);
    Console.WriteLine(s6);
    string s7=string.Concat(s3," ",s4);
    Console.WriteLine(s7);
    string s8=string.Format("{0} {1}",s3,s4);
    Console.WriteLine(s8);
    string s9=$"{s3} {s4}";
    Console.WriteLine(s9);
    Console.WriteLine(s3[0]);
    Console.WriteLine(s3.IndexOf('i'));
    Console.WriteLine(s3.Contains("i"));
    Console.WriteLine(s3.StartsWith("nit"));
    Console.WriteLine(s3.EndsWith("his"));
    Console.WriteLine(s3.Substring(0,3));
    Console.WriteLine(s3.Insert(3,"abc"));
    Console.WriteLine(s3.Remove(3,3));
    Console.WriteLine(s3.Replace('t','T'));
    Console.WriteLine(s3.PadLeft(15));
    Console.WriteLine(s3.PadRight(15));
    Console.WriteLine(s3.Trim());
    Console.WriteLine(s3.ToUpper());
    Console.WriteLine(s3.ToLower());
    Console.WriteLine(s3.Length);
    Console.WriteLine(s3.Reverse());
    Console.WriteLine(s3.Contains("this"));
    //task based on above mentioned classes
       string name="nithis bangaru";

        DateTime today = new DateTime(2025, 5, 10, 11, 30, 6);
        Console.WriteLine(" Today is: {0}, Month is {1}, year is {2}",today,today.DayOfWeek,today.Year);

        TimeSpan currentTime = new TimeSpan(14, 30, 0);
        TimeSpan meetingTime = new TimeSpan(17, 0, 0);  
        TimeSpan timeLeft = meetingTime - currentTime;
        Console.WriteLine("Time left for meeting: {0}", timeLeft);
 
        string taskCountStr = "5";
        int taskCount = int.Parse(taskCountStr);
        Console.WriteLine(" You have {0} tasks today.", taskCount);
 
        string floatStr = "12.34";
        int result1;
        bool success = Int32.TryParse(floatStr, out result1);
        Console.WriteLine("TryParse success: " + success);
 
 
        Random rand = new Random();
        int taskno = rand.Next(1, 6);
        Console.WriteLine("Day {0}", taskno);
 
        StringBuilder sb = new StringBuilder();
        sb.Append("Summary for ");
        sb.Append(name);
        sb.AppendJoin(": ");
        sb.AppendFormat(taskno.ToString());
        sb.Append(" tasks, assigned ");
        sb.Append(timeLeft.Hours);
        sb.Append(" hours and ");
        sb.Append(timeLeft.Minutes);
        sb.Append(" minutes.");
        Console.WriteLine(sb.ToString());
    }
}
 
 
    
 