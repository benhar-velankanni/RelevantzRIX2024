using System;
class ATMWithdrawal
{
    static void Main()
    {
        int balance = 10000;
        Console.Write("Enter withdrawal amount: ");
        int withdrawAmount = Convert.ToInt32(Console.ReadLine());

        if (withdrawAmount <= balance)
        {
            balance -= withdrawAmount;
            Console.WriteLine("Withdrawal successful");
            Console.WriteLine("Remaining balance: " + balance);
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }
}
