using LibraryCons;
using bookCons;
class Program
{
    static void Main()
    {
        Library library = new Library();

        library.AddBook("202", new Book { Title = "Book1", AuthorName = "Author1", year = 2025 });
        library.AddBook("203", new Book { Title = "Book2", AuthorName = "Author2", year = 2026 });
        library.AddBook("204", new Book { Title = "Book3", AuthorName = "Author3", year = 2027 });

        foreach (var book in library.GetAllBooks()) //using dictionary and list
        {
            Console.WriteLine($"using dictionary\n ISBN: {book["Isbn"]},  Title: {book["Title"]},Author: {book["AuthorName"]},Year: {book["year"]}");

        }
       foreach (var book in library.GetBooks()) //using enumerable
        {
            Console.WriteLine($"using enumerable\n ISBN: {book.Isbn},  Title: {book.Title},Author: {book.AuthorName},Year: {book.Year}");
        }
 
    }
}