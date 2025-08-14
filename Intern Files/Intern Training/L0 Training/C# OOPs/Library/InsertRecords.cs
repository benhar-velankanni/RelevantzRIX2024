public class InsertRecords
{
    public void Insertions(List<Book> books)
    {
        Console.WriteLine("\nEnter the number of Books: ");
        int n = int.Parse(Console.ReadLine());


        Console.WriteLine("\nEnter the details of the Books: ");
        Console.WriteLine("====================================");
        for (int i = 0; i < n; i++)
        {
            Book book = new Book();

            Console.Write("\nName: ");
            book.Name = Console.ReadLine();

            Console.Write("Author: ");
            book.Author = Console.ReadLine();

            Console.Write("Genre: ");
            book.Genre = Console.ReadLine();

            books.Add(book);
        }
    }
}