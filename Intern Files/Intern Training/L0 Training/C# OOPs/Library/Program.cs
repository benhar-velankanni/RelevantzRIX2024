//Ex: 2	Write a C# program to create a class called "Library" with a collection of books and methods to add and remove books.

using System.Security.Cryptography.X509Certificates;

class Library
{
    public static void Main()
    {
        List<Book> books = new List<Book>();
        InsertRecords insertRecords = new InsertRecords();
        DisplayRecords displayRecords = new DisplayRecords();
        DeleteRecords deleteRecords = new DeleteRecords();

    checkpoint1:
        Console.WriteLine("\nLibrary Record System:");
        Console.WriteLine("1.Insert Books.");
        Console.WriteLine("2.Delete Books.");
        Console.WriteLine("3.Display Books");
        Console.WriteLine("0.Exit.");
        Console.WriteLine("\nEnter your choice: ");
        int choice1 = Convert.ToInt32(Console.ReadLine());

        switch (choice1)
        {
            case 1:
                {
                    insertRecords.Insertions(books);
                    goto checkpoint1;
                }

            case 2:
                {
                    deleteRecords.deletions(books);
                    goto checkpoint1;
                }

            case 3:
                {

                    displayRecords.dispayRecords(books);
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