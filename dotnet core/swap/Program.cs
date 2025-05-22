public class NumberSwapper
{
    public void SwapNumbers(ref int num1, ref int num2)
    {
        int temp = num1;
        num1 = num2;
        num2 = temp;
    }
}

class Program
{
    static void Main()
    {
        NumberSwapper swapper = new NumberSwapper();
        int a = 5;
        int b = 10;

        Console.WriteLine("Before swap: a = " + a + ", b = " + b);

        swapper.SwapNumbers(ref a, ref b);

        Console.WriteLine("After swap: a = " + a + ", b = " + b);
    }
}

