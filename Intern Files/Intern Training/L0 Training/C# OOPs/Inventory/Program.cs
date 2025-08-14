//Ex: 2	Write a C# program to create a class called "Library" with a collection of books and methods to add and remove books.

using System.Security.Cryptography.X509Certificates;

class Inventory
{
    public static void Main()
    {
        List<Product> products = new List<Product>();
        InsertRecords insertRecords = new InsertRecords();
        DisplayRecords displayRecords = new DisplayRecords();
        DeleteRecords deleteRecords = new DeleteRecords();
        UpdateStock updateStock = new UpdateStock();
        LowInv lowInv = new LowInv();

    checkpoint1:
        Console.WriteLine("\nInventory System:");
        Console.WriteLine("1.Insert Stock Inventory.");
        Console.WriteLine("2.Delete Product Inventory.");
        Console.WriteLine("3.Update Product Inventory.");
        Console.WriteLine("4.Display Critical Inventory Only.");
        Console.WriteLine("5.Display Inventory.");
        Console.WriteLine("0.Exit.");
        Console.WriteLine("\nEnter your choice: ");
        int choice1 = Convert.ToInt32(Console.ReadLine());

        switch (choice1)
        {
            case 1:
                {
                    insertRecords.Insertions(products);
                    goto checkpoint1;
                }

            case 2:
                {
                    deleteRecords.deletions(products);
                    goto checkpoint1;
                }

            case 3:
                {
                    updateStock.update(products);
                    goto checkpoint1;
                }

            case 4:
                {
                    lowInv.Warn(products);
                    goto checkpoint1;
                }

            case 5:
                {

                    displayRecords.dispayRecords(products);
                    goto checkpoint1;
                }

            case 0:
                {
                    Console.WriteLine("\n======================");
                    Console.WriteLine("Logging Out...");
                    Console.WriteLine("======================");
                    return;
                }

            default:
                {
                    Console.WriteLine("\nInvalid Choice!! Try Again!!");
                    goto checkpoint1;
                }

        }
    }
}