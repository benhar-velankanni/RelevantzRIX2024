 
namespace bookCons
{
    public class Book
    {
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public int year { get; set; }
        public int Year { get; internal set; }
        public string? Isbn { get; internal set; }
    }
}
 