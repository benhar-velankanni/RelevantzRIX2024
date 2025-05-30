using bookCons;
using MySql.Data.MySqlClient;
 
namespace  LibraryCons
{
    public class Library
{
    public string conn = "server=localhost;user=root;Password=Password@12345;database=libraryCollections;port=3306";
    private IDictionary<string, Book> books = new Dictionary<string, Book>();
    public void AddBook(string isbn, Book book)
    {
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "INSERT INTO books (Isbn, Title, AuthorName,year) VALUES (@Isbn, @Title, @AuthorName, @year)";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@Isbn", isbn);
        cmd.Parameters.AddWithValue("@Title", book.Title);
        cmd.Parameters.AddWithValue("@AuthorName", book.AuthorName);
        cmd.Parameters.AddWithValue("@year", book.year);
            try
            {
            cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
            Console.WriteLine("Error: " + ex.Message);
            }    
       
        books[isbn] = book;
        Console.WriteLine($"Book added with ISBN: {isbn}");
    }

        //using dictionary and list
        public List<Dictionary<string, object>> GetAllBooks()
        {
            var books = new List<Dictionary<string, object>>();
            using var con = new MySqlConnection(conn);
            con.Open();
            string sql = "SELECT * FROM books";
            using var cmd = new MySqlCommand(sql, con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var book = new Dictionary<string, object>
                {
                    ["Isbn"] = reader["Isbn"],
                    ["Title"] = reader["Title"],
                    ["AuthorName"] = reader["AuthorName"],
                    ["year"] = reader["year"],

                };
                books.Add(book);


            }
            return books;

        }
        //using enumerable
        public IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>();
            using var con = new MySqlConnection(conn);
            con.Open();
            string sql = "SELECT * FROM books";
            using var cmd = new MySqlCommand(sql, con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var book = new Book
                {
                    Isbn = reader["Isbn"].ToString(),
                    Title = reader["Title"].ToString(),
                    AuthorName = reader["AuthorName"].ToString(),
                    Year = Convert.ToInt32(reader["year"])
                };
                books.Add(book);

            }
            return books;
        }

    
    public void DisplayAll()
        {
            Console.WriteLine("\n Displaying all books");
            foreach (var pair in books)
            {
                Console.WriteLine($"ISBN: {pair.Key}, Title: {pair.Value.Title}, Author: {pair.Value.AuthorName}");
            }
        }
}
}
 
 
 