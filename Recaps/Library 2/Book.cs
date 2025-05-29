using System;

namespace LibraryManagement
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | ISBN: {ISBN} | Title: {Title} | Author: {AuthorName} | Year: {PublicationYear}";
        }
    }
}