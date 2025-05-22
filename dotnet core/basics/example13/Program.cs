using System;

public class BankAccount
{
    private string accountNumber;
    private decimal balance;

    public string AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    public decimal Balance
    {
        get { return balance; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Invalid balance");
            }
            else
            {
                balance = value;
            }
        }
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds");
        }
        else
        {
            Balance -= amount;
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        Console.Write("Enter account number: ");
        account.AccountNumber = Console.ReadLine();

        Console.Write("Enter initial balance: ");
        account.Balance = decimal.Parse(Console.ReadLine());

        while (true)
        {
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter amount to deposit: ");
                    account.Deposit(decimal.Parse(Console.ReadLine()));
                    break;
                case "2":
                    Console.Write("Enter amount to withdraw: ");
                    account.Withdraw(decimal.Parse(Console.ReadLine()));
                    break;
                case "3":
                    Console.WriteLine($"Current Balance: {account.Balance}");
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}