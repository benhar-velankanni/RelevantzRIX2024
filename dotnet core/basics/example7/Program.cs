using System;

class ReverseNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int reverse = 0;

        while (number != 0)
        {
            int digit = number % 10;
            reverse = reverse * 10 + digit;
            number /= 10;
        }

        Console.WriteLine("Reversed number: " + reverse);
    }
}
