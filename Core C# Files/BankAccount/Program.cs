namespace Bank
{
    class BankAccount
    {
        private int accountNumber;
        private decimal balance;

        public BankAccount(int accountNumber)
        {
            this.accountNumber = accountNumber;
            this.balance = 0;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("\nInsufficient balance.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("\nWithdrawal successful. Current Balance: {0:F2} INR.", balance);
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(210821);

            while (true)
            {
                Console.WriteLine("=============================================\n Main Menu \n=============================================");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("0. Exit");
                Console.WriteLine("=============================================");

                Console.Write("Choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter amount to deposit: ");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        account.Deposit(depositAmount);
                        Console.WriteLine("\nDeposit successful. Current Balance: {0:F2} INR.", account.GetBalance());
                        break;
                    case 2:
                        Console.Write("\nEnter amount to withdraw: ");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        try
                        {
                            account.Withdraw(withdrawAmount);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        Console.WriteLine($"\nYour balance is: {account.GetBalance():F2} INR.");
                        break;
                    case 0:
                        Console.WriteLine("\nExiting application...");
                        return;
                    default:
                        Console.WriteLine("\nInvalid option, please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}