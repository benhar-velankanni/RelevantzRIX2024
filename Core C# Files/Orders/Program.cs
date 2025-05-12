namespace Orders
{
    enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Cancelled
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=========================== \nORDER STATUS MESSAGES \n===========================");
                Console.WriteLine("1. Pending\n2. Shipped\n3. Delivered\n4. Cancelled\n0. Exit");
                Console.Write("\nSelect an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine(GetOrderStatusMessage(OrderStatus.Pending));
                        break;
                    case 2:
                        Console.WriteLine(GetOrderStatusMessage(OrderStatus.Shipped));
                        break;
                    case 3:
                        Console.WriteLine(GetOrderStatusMessage(OrderStatus.Delivered));
                        break;
                    case 4:
                        Console.WriteLine(GetOrderStatusMessage(OrderStatus.Cancelled));
                        break;
                    case 0:
                        Console.WriteLine("\n=========================== \nExiting application.\n=========================== \n");
                        return;
                    default:
                        Console.WriteLine("\n=========================== \nInvalid option, please try again.\n=========================== \n");
                        break;
                }
            }
        }

        static string GetOrderStatusMessage(OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.Pending:
                    return "\n=========================== \nMessage: Your order is being processed.\n=========================== \n";
                case OrderStatus.Shipped:
                    return "\n=========================== \nMessage: Your order has been shipped.\n=========================== \n";
                case OrderStatus.Delivered:
                    return "\n=========================== \nMessage: Your order has been delivered.\n=========================== \n";
                case OrderStatus.Cancelled:
                    return "\n=========================== \nMessage: Your order has been cancelled.\n=========================== \n";
                default:
                    return "\n=========================== \nMessage: Invalid order status.\n=========================== \n";
            }
        }
    }
}

