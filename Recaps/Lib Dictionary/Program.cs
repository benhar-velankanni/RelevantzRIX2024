using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public int year { get; set; }

    public override string ToString()
    {
        return $"{Title}, written by author {AuthorName} in the year {year}.";
    }
}

class Library
{
    Dictionary<string, Book> books = new Dictionary<string, Book>();

    public void Addbook(string id, Book book)
    {
        books.Add(id, book);
    }

    public void BookCount()
    {
        Console.WriteLine($"The library has {books.Count} books.");
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine("\nLibrary inventory:");
        foreach (Book book in books.Values)
        {
            Console.WriteLine(book.ToString());
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();
        library.Addbook("1", new Book { Title = "The Lord of the Rings", AuthorName = "JRR Tolkien", year = 1954 });
        library.Addbook("2", new Book { Title = "The Da Vinci Code", AuthorName = "Dan Brown", year = 2003 });
        library.Addbook("3", new Book { Title = "The Alchemist", AuthorName = "Paulo Coelho", year = 1988 });
        library.Addbook("4", new Book { Title = "The Hobbit", AuthorName = "JRR Tolkien", year = 1937 });
        library.Addbook("5", new Book { Title = "The Hunger Games", AuthorName = "Suzanne Collins", year = 2008 });
        library.Addbook("6", new Book { Title = "Pride and Prejudice", AuthorName = "Jane Austen", year = 1813 });
        library.Addbook("7", new Book { Title = "To Kill a Mockingbird", AuthorName = "Harper Lee", year = 1960 });
        library.Addbook("8", new Book { Title = "The Catcher in the Rye", AuthorName = "J.D. Salinger", year = 1951 });
        library.Addbook("9", new Book { Title = "1984", AuthorName = "George Orwell", year = 1949 });
        library.Addbook("10", new Book { Title = "The Great Gatsby", AuthorName = "F. Scott Fitzgerald", year = 1925 });

        library.BookCount();
        library.DisplayAllBooks();
    }
}