public class DisplayRecords{
    public void dispayRecords(List<Book> books){
        Console.WriteLine("\n============================");
        Console.WriteLine("The Books of Grand Library: ");
        Console.WriteLine("============================");

        foreach (Book book in books)
        {
            Console.WriteLine($"\nName: {book.Name} \nAuthor: ${book.Author} \nGenre: {book.Genre}");
        }
    }
}