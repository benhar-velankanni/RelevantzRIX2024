using System;
using System.Linq;

class AnagramChecker
{
    public bool AreAnagrams(string str1, string str2)
    {
        str1 = str1.Replace(" ", "").ToLower();
        str2 = str2.Replace(" ", "").ToLower();

        if (str1.Length != str2.Length)
        {
            return false;
        }

        char[] charArray1 = str1.ToCharArray();
        char[] charArray2 = str2.ToCharArray();

        Array.Sort(charArray1);
        Array.Sort(charArray2);

        return charArray1.SequenceEqual(charArray2);
    }
}

class Program
{
    public static void Main()
    {
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();

        AnagramChecker checker = new AnagramChecker();
        bool areAnagrams = checker.AreAnagrams(str1, str2);

        if (areAnagrams)
        {
            Console.WriteLine("The strings are anagrams.");
        }
        else
        {
            Console.WriteLine("The strings are not anagrams.");
        }
    }
}