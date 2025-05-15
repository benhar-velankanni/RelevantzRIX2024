using GenricApplication;

namespace GenricApplication
{

    public class UsingGeneric<T>
    {
        private T a;
        private T b;

        public UsingGeneric(T x, T y)
        {
            a = x;
            b = y;
        }

        public bool CompareResult()
        {
            if (a.Equals(b))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
class Program
{

    public static void Main()
    {


        UsingGeneric<string> stringGenvalue = new UsingGeneric<string>("Nisanth", "Saravanan");
        UsingGeneric<int> intGenintvalue = new UsingGeneric<int>(100, 100);

        Console.WriteLine(stringGenvalue.CompareResult());
        Console.WriteLine(intGenintvalue.CompareResult());
    }
}
