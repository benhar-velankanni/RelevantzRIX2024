using System;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
 
public class UsingThread
{
    static void Function1()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Function1 " + i.ToString());
        }
    }
    static void Function2()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Function2 " + i.ToString());
        }
    }
    public static void Main(string[] args)
    {
        Thread t1 = new Thread(new ThreadStart(Function1));
        Thread t2 = new Thread(new ThreadStart(Function2));
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
    }
}
 
 