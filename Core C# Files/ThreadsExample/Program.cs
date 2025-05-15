namespace ThreadMultithreadApp
{
    public class UsingTread
    {
        public static void Function1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Function 1: " + i);
                Thread.Sleep(1000);
            }
        }
        public static void Function2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Function 2: " + i);
                Thread.Sleep(1000);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(UsingTread.Function1);
            Thread t2 = new Thread(UsingTread.Function2);
            t1.Start();
            t2.Start();
        }
    }
}