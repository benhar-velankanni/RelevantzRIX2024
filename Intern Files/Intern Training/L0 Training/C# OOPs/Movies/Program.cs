//Ex: 6	Write a C# program to create a class called "Movie" with attributes for title, director, actors, and reviews, and methods for adding and retrieving reviews.

using System.Security.Cryptography.X509Certificates;

class IMDB
{
    public static void Main()
    {
        List<Movie> movies = new List<Movie>();
        InsertRecords insertRecords = new InsertRecords();
        DisplayRecords displayRecords = new DisplayRecords();
        DeleteRecords deleteRecords = new DeleteRecords();
        InsertReviews insertReviews= new InsertReviews();
        DeleteReviews deleteReviews= new DeleteReviews();

    checkpoint1:
        Console.WriteLine("\nMovie Catalog System:");
        Console.WriteLine("1.Insert Records.");
        Console.WriteLine("2.Delete Records.");
        Console.WriteLine("3.Insert Reviews.");
        Console.WriteLine("4.Delete Reviews.");
        Console.WriteLine("5.Display Records");
        Console.WriteLine("0.Exit.");
        Console.WriteLine("\nEnter your choice: ");
        int choice1 = Convert.ToInt32(Console.ReadLine());

        switch (choice1)
        {
            case 1:
                {
                    insertRecords.Insertions(movies);
                    goto checkpoint1;
                }

            case 2:
                {
                    deleteRecords.deletions(movies);
                    goto checkpoint1;
                }

            case 3:
                {

                    insertReviews.insertReview(movies);
                    goto checkpoint1;
                }

            case 4:
                {

                    deleteReviews.deleteReview(movies);
                    goto checkpoint1;
                }

            case 5:
                {

                    displayRecords.dispayRecords(movies);
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