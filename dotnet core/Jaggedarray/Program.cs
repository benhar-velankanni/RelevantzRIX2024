using System;

class Program
{
    static void Main(string[] args)
    {
        int[][] studentMarks = new int[3][];

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter number of subjects for student {i + 1}: ");
            int subjects = Convert.ToInt32(Console.ReadLine());

            studentMarks[i] = new int[subjects];

            for (int j = 0; j < subjects; j++)
            {
                Console.Write($"Enter mark for subject {j + 1}: ");
                studentMarks[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        for (int i = 0; i < 3; i++)
        {
            double average = CalculateAverage(studentMarks[i]);
            Console.WriteLine($"Average marks for student {i + 1}: {average}");
        }
    }

    static double CalculateAverage(int[] marks)
    {
        int sum = 0;
        foreach (int mark in marks)
        {
            sum += mark;
        }
        return (double)sum / marks.Length;
    }
}