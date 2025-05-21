using System;

namespace Crud
{
    class Maina
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------------\n ASSET MANAGEMENT SYSTEM\n------------------------------------------------");
            while (true)
            {
                Console.WriteLine("1. Add product");
                Console.WriteLine("2. View products");
                Console.WriteLine("3. Update product");
                Console.WriteLine("4. Delete product");
                Console.WriteLine("5. Search product");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice");
                int choice = int.Parse(Console.ReadLine());
                IAsset pr = new Program();
                switch (choice)
                {
                    case 1:
                        pr.AddAsset();
                        break;
                    case 2:
                        pr.ViewAsset();
                        break;
                    case 3:
                        pr.UpdateAsset();
                        break;
                    case 4:
                        pr.DeleteAsset();
                        break;
                    case 5:
                        pr.SearchAsset();
                        break;
                    case 6:
                        Console.WriteLine("Exiting");
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                Console.WriteLine("------------------------------------------------");
            }
        }
    }
}