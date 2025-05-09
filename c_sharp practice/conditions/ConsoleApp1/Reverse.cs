
public class Reverse
{
    public void revDigit()
    {
        Console.WriteLine("Enter a number");
        int n=Convert.ToInt32(Console.ReadLine());
        int num=n;
        int rev=0;
        while(num>0)
        {
            int temp=num%10;
            rev=(rev*10)+temp;
            num=num/10;
        }
        Console.WriteLine($"Reversed Digit is "+rev);
    }
}
