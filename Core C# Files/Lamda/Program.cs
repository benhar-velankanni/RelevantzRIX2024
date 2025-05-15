namespace UsingLamdaExpression
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GetEvenNumbers.EvenNumbers();
        }
    }

    public class GetEvenNumbers
    {
        public static void EvenNumbers()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            List<int> evenNumbers = list.FindAll(x => (x % 2) == 0);
            foreach (var num in evenNumbers)
            {
                Console.WriteLine($"Data: {num}");
            }
        }
    }
}

