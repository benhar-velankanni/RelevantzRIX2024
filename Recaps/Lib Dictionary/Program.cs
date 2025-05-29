using System;
using System.Collections.Generic;

public class Book
{
    public string? Title { get; set; }
    public string? AuthorName { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return $"{Title} by {AuthorName} ({Year})";
    }
}

class Library
{
    Dictionary<string, Book>? books;

    public void AddBook(string id, Book book)
    {
        if (books.ContainsKey(id)) 
        {
            Console.WriteLine("Error: Book ID already exists!");
            return;
        }
        books.Add(id, book);
        Console.WriteLine("Book added successfully!");
    }

    public void DisplayAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        Console.WriteLine("\nLibrary Books:");
        Console.WriteLine("-------------");
        foreach (var kvp in books)
        {
            Console.WriteLine($"ID: {kvp.Key} - {kvp.Value}");
        }
    }

    public void UpdateBook(string id)
    {
        if (!books.ContainsKey(id))
        {
            Console.WriteLine("Error: Book not found!");
            return;
        }

        var book = books[id];
        Console.WriteLine($"Updating: {book.Title}");

        Console.Write("Enter new title (or press Enter to keep current): ");
        string? newTitle = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newTitle))
            book.Title = newTitle;

        Console.Write("Enter new author (or press Enter to keep current): ");
        string? newAuthor = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newAuthor))
            book.AuthorName = newAuthor;

        Console.Write("Enter new year (or press Enter to keep current): ");
        string? yearInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(yearInput) && int.TryParse(yearInput, out int newYear))
            book.Year = newYear;

        Console.WriteLine("Book updated successfully!");
    }

    public void DeleteBook(string id)
    {
        if (!books.ContainsKey(id))
        {
            Console.WriteLine("Error: Book not found!");
            return;
        }

        var book = books[id];
        Console.WriteLine($"Are you sure you want to delete '{book.Title}'? (y/n)");

        if (Console.ReadLine()?.ToLower() == "y")
        {
            books.Remove(id);
            Console.WriteLine("Book deleted successfully!");
        }
        else
        {
            Console.WriteLine("Delete cancelled.");
        }
    }

    public void SearchBook(string id)
    {
        if (books.ContainsKey(id))
        {
            Console.WriteLine($"Found: ID {id} - {books[id]}");
        }
        else
        {
            Console.WriteLine("Book not found!");
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();
        bool running = true;

        while (running)
        {
            DisplayMenu();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateBook(library);
                    break;
                case "2":
                    library.DisplayAllBooks();
                    break;
                case "3":
                    UpdateBook(library);
                    break;
                case "4":
                    DeleteBook(library);
                    break;
                case "5":
                    SearchBook(library);
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Library Management System");
        Console.WriteLine("========================");
        Console.WriteLine("1. Add a new book");
        Console.WriteLine("2. Display all books");
        Console.WriteLine("3. Update a book");
        Console.WriteLine("4. Delete a book");
        Console.WriteLine("5. Search for a book");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
    }

    static void CreateBook(Library library)
    {
        Console.WriteLine("\nAdd New Book");
        Console.WriteLine("------------");

        Console.Write("Enter Book ID: ");
        string? id = Console.ReadLine();

        Console.Write("Enter Title: ");
        string? title = Console.ReadLine();

        Console.Write("Enter Author: ");
        string? author = Console.ReadLine();

        Console.Write("Enter Year: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            library.AddBook(id ?? "", new Book { Title = title ?? "", AuthorName = author ?? "", Year = year });
        }
        else
        {
            Console.WriteLine("Invalid year format!");
        }
    }

    static void UpdateBook(Library library)
    {
        Console.WriteLine("\nUpdate Book");
        Console.WriteLine("-----------");
        Console.Write("Enter Book ID to update: ");
        string? id = Console.ReadLine();
        library.UpdateBook(id ?? "");
    }

    static void DeleteBook(Library library)
    {
        Console.WriteLine("\nDelete Book");
        Console.WriteLine("-----------");
        Console.Write("Enter Book ID to delete: ");
        string? id = Console.ReadLine();
        library.DeleteBook(id ?? "");
    }

    static void SearchBook(Library library)
    {
        Console.WriteLine("\nSearch Book");
        Console.WriteLine("-----------");
        Console.Write("Enter Book ID to search: ");
        string? id = Console.ReadLine();
        library.SearchBook(id ?? "");
    }
}