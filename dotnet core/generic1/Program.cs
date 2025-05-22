using System;
using System.Collections.Generic;
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
    class Program{
 
    public static void Main(){
 
 
      UsingGeneric<string> intstGenvalue=new UsingGeneric<string>("Nithis","Bangaru");
      UsingGeneric<int> intstGenintvalue=new UsingGeneric<int>(100,100);
 
      Console.WriteLine(intstGenvalue.CompareResult());
      Console.WriteLine(intstGenintvalue.CompareResult());
}
}
 
}
 
 