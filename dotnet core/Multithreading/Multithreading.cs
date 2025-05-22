using System;
using System.Threading;

namespace Multithreading
{
    public class Usingthreadaddition
    {
        public static void function1()
        {
            for(int i=0;i<5;i++)
            {
                Console.WriteLine("Function 1"+i.ToString());
                Thread.Sleep(1000);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Usingthreadaddition.function1));
            t1.Start();
        }
        }

}