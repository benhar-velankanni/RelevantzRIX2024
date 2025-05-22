using System.ComponentModel;
using System.Text;

class Training
{
    public string topic;
            
    //default constructor
    public Training()
            {
                topic="C#";
                Console.WriteLine(topic);
            }

    //parameterized constructor
    public Training(string topic){
                this.topic=topic;
               Console.WriteLine(topic);
            }

    //multilevel parameterized constructor
    public Training(string topic,string trainer){
                this.topic=topic;
                Console.WriteLine("{0},{1}",topic,trainer);
            }
}
class Excercise{
    public static void Main(string[] args)
    {
        // Console.WriteLine("The value 77777 in various formats");
        // Console.WriteLine("c format: {0:c}", 77777);
//         Console.WriteLine("d9 format: {0:d9}", 77777);
//         Console.WriteLine("f3 format: {0:f3}", 77777);
//         Console.WriteLine("n format: {0:n}", 77777);
    
//     Console.WriteLine("E format: {0:E}", 77777);
//     Console.WriteLine("e format: {0:e}", 77777);
//     Console.WriteLine("X format: {0:X}", 77777);
//     Console.WriteLine("x format: {0:x}", 77777);
//     int maximum = int.MaxValue;
//     Console.WriteLine("maximum value:"+ maximum);
//     short maximumshort = short.MaxValue;
//     Console.WriteLine("maximum value for short:"+ maximumshort);
//     double maximumdouble = double.MaxValue;
//     Console.WriteLine("maximum value for double:"+ maximumdouble);
//     float maximumfloat = float.MaxValue;
//     Console.WriteLine("maximum value for float:"+ maximumfloat);
//     decimal maximumdecimal = decimal.MaxValue;
//     Console.WriteLine("maximum value for decimal:"+ maximumdecimal);
//     long maximumlong = long.MaxValue;
//     Console.WriteLine("maximum value for long:"+ maximumlong);
//     Console.WriteLine("-------------------------------------------------------------");

// //usiage of classes

//     //date functions
//     DateTime dt =new DateTime(2025,05,10);
//     //constructor values(year,month,day)
//     Console.WriteLine("The day of {0},is {1}",dt.Date,dt.DayOfWeek,dt.DayOfYear);
//     Console.WriteLine("-------------------------------------------------------------");

//     TimeSpan ts = new TimeSpan(9,47,25);
//     //constructor values (hours,minutes,seconds)
//     Console.WriteLine("The time of is {0}",ts); 
//     Console.WriteLine("-------------------------------------------------------------");

//     string firstname="Mukesh";
//     Console.WriteLine("Has {0} characters",firstname.Length);
//     //using methods
//     Console.WriteLine("To Uppercase:"+firstname.ToUpper());
//     Console.WriteLine("To Lowercase: "+firstname.ToLower());
//     Console.WriteLine("Index of e: "+firstname.IndexOf("e"));
//     Console.WriteLine("replace e with a: "+firstname.Replace("e","a"));
//     Console.WriteLine("-------------------------------------------------------------");

//     //Conversion
//     string number="12572";
//     int result;
//     result=int.Parse(number);
//     Console.WriteLine(result);
//     Console.WriteLine("-------------------------------------------------------------");

//    string s2="1234.56";
//    bool successoutput;
//    successoutput= Int32.TryParse(s2,out result);
//    Console.WriteLine(successoutput);
//    Console.WriteLine("-------------------------------------------------------------");


// string str="c# learning using vs code";
// string stw="";
// Console.WriteLine("is Empty:"+string.IsNullOrEmpty(stw));
// Console.WriteLine("is Empty:"+string.IsNullOrWhiteSpace(str));
// Console.WriteLine("is Empty:"+string.IsNullOrEmpty(str));
// Random r=new Random();
// Console.WriteLine("Random numbers between 1 and 10: "+r.Next(1,11));
// Console.WriteLine("-------------------------------------------------------------");

// //string builder handle the string function

// StringBuilder sb=new StringBuilder();
// sb.Append("Hello");
// sb.Append("World");
// Console.WriteLine(sb);
// Console.WriteLine(sb.Replace("World","Mukesh"));
// Console.WriteLine("-------------------------------------------------------------");
// Console.WriteLine("-------------------------------------------------------------");



// //task based on above mentioned classes

//         Console.WriteLine("Daily Planner Summary Report");
//         Console.WriteLine("==================================================");
//         // 1. DateTime - Show today's date and day
//         DateTime today = new DateTime(2025, 5, 10, 11, 30, 6);
//         Console.WriteLine(" Today is: {0}, Month is {1}, year is {2}",today,today.DayOfWeek,today.Year);
       
        

//         // 2. TimeSpan - Time left until a meeting at 3:00 PM
        
//         TimeSpan currentTime = new TimeSpan(10, 30, 0); // 10:30 AM
//         TimeSpan meetingTime = new TimeSpan(15, 0, 0);  // 3:00 PM
//         TimeSpan timeLeft = meetingTime - currentTime;
//         Console.WriteLine(" Time left for meeting: {0}", timeLeft);
//         Console.WriteLine("-------------------------------------------------------------");

//         // 3. String - User's name
//         string name = "Mukesh";
//         Console.WriteLine(" Hello, {0}!", name);
//         Console.WriteLine("Uppercase: " + name.ToUpper());
//         Console.WriteLine("Lowercase: " + name.ToLower());
//         Console.WriteLine("Index of 'e': " + name.IndexOf('e'));
//         Console.WriteLine("Replace 'e' with 'a': " + name.Replace('e', 'a'));
//         Console.WriteLine("-------------------------------------------------------------");

//         // 4. Conversion - Convert task count from string to int
//         string taskCountStr = "5";
//         int taskCount = int.Parse(taskCountStr);
//         Console.WriteLine(" You have {0} tasks today.", taskCount);
//         Console.WriteLine("-------------------------------------------------------------");

//         // 5. TryParse - Try converting a float string to int
//         string floatStr = "12.34";
//         int result1;
//         bool success = Int32.TryParse(floatStr, out result);
//         Console.WriteLine("TryParse success: " + success);
//         Console.WriteLine("-------------------------------------------------------------");

//         // 6. String checks
//         string emptyStr = null;
//         Console.WriteLine("Is empty string null or empty? " + string.IsNullOrEmpty(emptyStr));
//         Console.WriteLine("Is name string null or whitespace? " + string.IsNullOrWhiteSpace(name));
//         Console.WriteLine("-------------------------------------------------------------");

//         // 7. Random - Pick a random motivational quote number
//         Random rand = new Random();
//         int quoteNumber = rand.Next(1, 10); 
//         Console.WriteLine(" Motivational Quote #{0}", quoteNumber);
//         Console.WriteLine("================================================================");

//         int taskCount1=5;
//         Console.WriteLine("Square root of task count: " + Math.Sqrt(taskCount1));


//         // 8. StringBuilder - Build a summary message
//         StringBuilder summary = new StringBuilder();
//         summary.Append("Summary for ");
//         summary.Append(name);
//         summary.Append(": ");
//         summary.Append(taskCount);
//         summary.Append(" tasks, meeting in ");
//         summary.Append(timeLeft.Hours);
//         summary.Append(" hours and ");
//         summary.Append(timeLeft.Minutes);
//         summary.Append(" minutes.");
//         Console.WriteLine(summary.ToString());
//         Console.WriteLine("...........................................................");

    Training t = new Training();
    Training t1 = new Training("C#","Mukesh");
    Training t2 = new Training("C#");

    }
}







    
    
    
    






