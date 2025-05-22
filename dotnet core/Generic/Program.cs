namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaximumGeneric<int>(10, 20, 30));
            Console.WriteLine(MaximumGeneric<double>(10.5, 20.8, 30.9));
            Console.WriteLine(MaximumGeneric<char>('a', 'b', 'c'));
        }
 
        static T MaximumGeneric<T>(T a, T b, T c) where T : IComparable
        {
            if (a.CompareTo(b) > 0 && a.CompareTo(c) > 0)
                return a;
            else if (b.CompareTo(a) > 0 && b.CompareTo(c) > 0)
                return b;
            else
                return c;
        }
    }
}
 
 