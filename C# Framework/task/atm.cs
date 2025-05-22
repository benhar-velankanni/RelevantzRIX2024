public class ATM
{
    public void withdraw()
    {
        Console.WriteLine("Enter amount");
        double balance=10000;
        double amount=Convert.ToDouble(Console.ReadLine());
        if(amount<=balance )
        {
            Console.WriteLine("Withdraw Successfull");
            balance=balance-amount;
         
            Console.WriteLine($"Current Balance is {balance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
 
 
    }
}
 