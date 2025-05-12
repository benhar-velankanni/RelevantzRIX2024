namespace AnagramChecker
{
    class Program
    {
        static void Main(string[] args)
        {
        checkpoint1:
            Console.WriteLine("\n===========================\nWelcome to AnagramChecker! \n===========================");
            Console.Write("Enter a string for comparison 1: ");
            string? str1 = Console.ReadLine();
            Console.Write("Enter a string for comparison 2: ");
            string? str2 = Console.ReadLine();

            Console.WriteLine("\n===========================\nGiven Strings:");
            Console.WriteLine($"str1 = {str1}, \nstr2 = {str2} \n===========================");

            bool result = AreAnagrams(str1, str2);

            Console.WriteLine("\n===========================\nFinal Result:");
            Console.WriteLine($"{result} \n===========================\n");

            Console.WriteLine("Wish to continue for another pair? [Y/N]");
            string? choice = Console.ReadLine()?.ToLower();
            if (choice == "y")
            {
                goto checkpoint1;
            }
            else if (choice == "n")
            {
                Console.WriteLine("Exiting...");
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Exiting...");
            }
        }

        public static bool AreAnagrams(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            char[] charArray1 = str1.ToLower().ToCharArray();
            char[] charArray2 = str2.ToLower().ToCharArray();

            Array.Sort(charArray1);
            Array.Sort(charArray2);

            return charArray1.SequenceEqual(charArray2);
        }
    }
}

