namespace ConsoleAppRelevantz
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n====================================================\nMAIN MENU!\n====================================================");
                Console.WriteLine("1. ADD A PRODUCT");
                Console.WriteLine("2. DELETE A PRODUCT");
                Console.WriteLine("3. UPDATE A PRODUCT");
                Console.WriteLine("4. SEARCH A PRODUCT");
                Console.WriteLine("5. LIST PRODUCTS");
                Console.WriteLine("6. TRUNCATE TABLE");
                Console.WriteLine("0. EXIT");
                Console.WriteLine("====================================================");
                Console.Write("ENTER YOUR CHOICE: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RelevantzProducts.AddProduct();
                        break;
                    case "2":
                        RelevantzProducts.DeleteProduct();
                        break;
                    case "3":
                        RelevantzProducts.UpdateProduct();
                        break;
                    case "4":
                        RelevantzProducts.SearchProduct();
                        break;
                    case "5":
                        RelevantzProducts.ListProducts();
                        break;
                    case "6":
                        RelevantzProducts.TruncateTable();
                        break;
                    case "0":
                        Console.WriteLine("\n====================================================\nEXITING!\n====================================================");
                        return;
                    default:
                        Console.WriteLine("\n====================================================\nINVALID INPUT. PLEASE TRY AGAIN.\n====================================================");
                        break;
                }
            }
        }
    }
}