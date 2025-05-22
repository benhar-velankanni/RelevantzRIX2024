using System;

class StudentGradingSystem
{
    static void Main()
    {
        Console.Write("Enter marks: ");
        int marks = Convert.ToInt32(Console.ReadLine());

        if (marks >= 90 && marks <= 100)
        {
            Console.WriteLine("Grade A");
        }
        else if (marks >= 75 && marks < 90)
        {
            Console.WriteLine("Grade B");
        }
        else if (marks >= 50 && marks < 75)
        {
            Console.WriteLine("Grade C");
        }
        else
        {
            Console.WriteLine("Fail");
        }
    }
}