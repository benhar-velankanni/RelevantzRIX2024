using System;
using System.Text;

namespace Types
{
    class Trainer
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Trainer(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("\nTrainer created: \n=====================================");
            Console.WriteLine($"Trainer name: {Name}");
            Console.WriteLine($"Trainer age: {Age}");
        }

        public void DisplayDetails()
        {
            Console.WriteLine("\nTrainer details from display method: \n=====================================");
            Console.WriteLine($"Trainer name: {Name}");
            Console.WriteLine($"Trainer age: {Age}");
        }
    }

    class Program
    {
        private static void Main(string[] args)
        {
            Trainer trainer = new Trainer("John Doe", 30);
            trainer.DisplayDetails();

            // Access modifiers demonstration
            AccessModifiersDemo accessDemo = new AccessModifiersDemo();
            accessDemo.PublicMethod();
            // accessDemo.PrivateMethod(); // Error: Inaccessible due to its protection level
            // accessDemo.ProtectedMethod(); // Error: Inaccessible due to its protection level
            accessDemo.InternalMethod();
            accessDemo.ProtectedInternalMethod();
            // accessDemo.PrivateProtectedMethod(); // Error: Inaccessible due to its protection level

            // Implicit type casting
            int num = 123;
            double doubleNum = num; // int to double

            Console.WriteLine("\nImplicit type casting");
            Console.WriteLine($"{num} -> {doubleNum}");

            // Explicit type casting
            double pi = 3.14;
            int intPi = (int)pi; // double to int

            Console.WriteLine("\nExplicit type casting");
            Console.WriteLine($"{pi} -> {intPi}");

            // Creating DateTime object
            DateTime now = DateTime.Now;

            Console.WriteLine("\nCreating DateTime object");
            Console.WriteLine($"{now}");

            // Creating DateTime object with parameters
            DateTime specifiedDate = new DateTime(2020, 10, 10);

            Console.WriteLine("\nCreating DateTime object with parameters");
            Console.WriteLine($"{specifiedDate}");

            // Using AddDays method
            DateTime futureDate = now.AddDays(7);

            Console.WriteLine("\nUsing AddDays method");
            Console.WriteLine($"{now} -> {futureDate}");

            // Using AddHours method
            DateTime futureTime = now.AddHours(2);

            Console.WriteLine("\nUsing AddHours method");
            Console.WriteLine($"{now} -> {futureTime}");

            // Using AddMinutes method
            DateTime futureTime2 = now.AddMinutes(30);

            Console.WriteLine("\nUsing AddMinutes method");
            Console.WriteLine($"{now} -> {futureTime2}");

            // Using AddMonths method
            DateTime futureMonth = now.AddMonths(3);

            Console.WriteLine("\nUsing AddMonths method");
            Console.WriteLine($"{now} -> {futureMonth}");

            // Using AddSeconds method
            DateTime futureSecond = now.AddSeconds(10);

            Console.WriteLine("\nUsing AddSeconds method");
            Console.WriteLine($"{now} -> {futureSecond}");

            // Using AddYears method
            DateTime futureYear = now.AddYears(5);

            Console.WriteLine("\nUsing AddYears method");
            Console.WriteLine($"{now} -> {futureYear}");

            // Using ToShortDateString method
            string shortDate = now.ToShortDateString();

            Console.WriteLine("\nUsing ToShortDateString method");
            Console.WriteLine($"{now} -> {shortDate}");

            // Using ToLongDateString method
            string longDate = now.ToLongDateString();

            Console.WriteLine("\nUsing ToLongDateString method");
            Console.WriteLine($"{now} -> {longDate}");

            // Using ToShortTimeString method
            string shortTime = now.ToShortTimeString();

            Console.WriteLine("\nUsing ToShortTimeString method");
            Console.WriteLine($"{now} -> {shortTime}");

            // Using ToLongTimeString method
            string longTime = now.ToLongTimeString();

            Console.WriteLine("\nUsing ToLongTimeString method");
            Console.WriteLine($"{now} -> {longTime}");

            // Using ToString method
            string dateTimeString = now.ToString();

            Console.WriteLine("\nUsing ToString method");
            Console.WriteLine($"{now} -> {dateTimeString}");

            // TimeSpan methods
            TimeSpan timeSpan = new TimeSpan(1, 0, 0);

            Console.WriteLine("\nTimeSpan methods: \n=====================================");
            Console.WriteLine($"TimeSpan duration: {timeSpan.Duration()}");
            Console.WriteLine($"TimeSpan add: {timeSpan.Add(new TimeSpan(0, 0, 5))}");
            Console.WriteLine($"TimeSpan subtract: {timeSpan.Subtract(new TimeSpan(0, 0, 5))}");
            Console.WriteLine($"TimeSpan total hours: {timeSpan.TotalHours}");
            Console.WriteLine($"TimeSpan total minutes: {timeSpan.TotalMinutes}");
            Console.WriteLine($"TimeSpan total seconds: {timeSpan.TotalSeconds}");
            Console.WriteLine($"TimeSpan total milliseconds: {timeSpan.TotalMilliseconds}");
            Console.WriteLine($"TimeSpan total days: {timeSpan.TotalDays}");

            // String methods
            string greeting = "Hello World!";

            Console.WriteLine("\nString methods: \n=====================================");
            Console.WriteLine($"String length: {greeting.Length}");
            Console.WriteLine($"String uppercase: {greeting.ToUpper()}");
            Console.WriteLine($"String lowercase: {greeting.ToLower()}");
            Console.WriteLine($"String substring: {greeting.Substring(0, 5)}");
            Console.WriteLine($"String contains: {greeting.Contains("World")}");
            Console.WriteLine($"String start with: {greeting.StartsWith("Hello")}");
            Console.WriteLine($"String end with: {greeting.EndsWith("!")}");
            Console.WriteLine($"String index of: {greeting.IndexOf("World")}");
            Console.WriteLine($"String last index of: {greeting.LastIndexOf("World")}");
            Console.WriteLine($"String insert: {greeting.Insert(5, " Beautiful")}");
            Console.WriteLine($"String remove: {greeting.Remove(6, 5)}");
            Console.WriteLine($"String replace: {greeting.Replace("World", "Universe")}");
            Console.WriteLine($"String trim: {greeting.Trim()}");
            Console.WriteLine($"String trim start: {greeting.TrimStart()}");
            Console.WriteLine($"String trim end: {greeting.TrimEnd()}");
            Console.WriteLine($"String split: {string.Join(", ", greeting.Split(' '))}");
            Console.WriteLine($"String reverse: {string.Join("", greeting.Reverse())}");
            Console.WriteLine($"String format: {string.Format($"Hello {0}!", "World")}");
            Console.WriteLine($"String concat: {string.Concat("Hello", " ", "World")}");

            // Demonstrating Random class
            Random random = new Random();
            int randomNumber = random.Next(1, 100); // Random number between 1 and 100

            Console.WriteLine("\nRandom class");
            Console.WriteLine($"Random number: {randomNumber}");

            // Demonstrating StringBuilder class
            StringBuilder sb = new StringBuilder();

            sb.Append("Hello");
            sb.Append(" ");
            sb.Append("StringBuilder!");

            Console.WriteLine("\nStringBuilder class");
            Console.WriteLine(sb.ToString());

            // Demonstrating Math class methods
            double number = 16.75;

            Console.WriteLine("\nMath class methods: \n=====================================");
            Console.WriteLine($"Ceiling of {number}: {Math.Ceiling(number)}");
            Console.WriteLine($"Floor of {number}: {Math.Floor(number)}");
            Console.WriteLine($"Round of {number}: {Math.Round(number)}");
            Console.WriteLine($"Square root of 25: {Math.Sqrt(25)}");
            Console.WriteLine($"Power of 2^3: {Math.Pow(2, 3)}");
        }
    }

    class AccessModifiersDemo
    {
        public void PublicMethod()
        {
            Console.WriteLine("\nThis is a public method.");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("\nThis is a private method.");
        }

        protected void ProtectedMethod()
        {
            Console.WriteLine("\nThis is a protected method.");
        }

        internal void InternalMethod()
        {
            Console.WriteLine("\nThis is an internal method.");
        }

        protected internal void ProtectedInternalMethod()
        {
            Console.WriteLine("\nThis is a protected internal method.");
        }

        private protected void PrivateProtectedMethod()
        {
            Console.WriteLine("\nThis is a private protected method.");
        }
    }
}

