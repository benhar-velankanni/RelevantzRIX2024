using System;
using System.Globalization;

namespace LibraryManagement
{
    class Program
    {
        private static readonly DatabaseService dbService = new DatabaseService();

        static void Main(string[] args)
        {
            Console.WriteLine("=== Library Management System ===");

            // Test database connection
            if (!dbService.TestConnection())
            {
                Console.WriteLine("Failed to connect to database. Please check your connection settings.");
                return;
            }

            Console.WriteLine("Database connected successfully!\n");

            while (true)
            {
                ShowMenu();
                var choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        AddNewBook();
                        break;
                    case 2:
                        ViewAllBooks();
                        break;
                    case 3:
                        SearchBook();
                        break;
                    case 4:
                        UpdateBook();
                        break;
                    case 5:
                        DeleteBook();
                        break;
                    case 6:
                        Console.WriteLine("Thank you for using Library Management System!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Add New Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Search Book by ISBN");
            Console.WriteLine("4. Update Book");
            Console.WriteLine("5. Delete Book");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter your choice (1-6): ");
        }

        static int GetUserChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            return 0;
        }

        static void AddNewBook()
        {
            Console.WriteLine("\n=== Add New Book ===");

            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(isbn))
            {
                Console.WriteLine("ISBN cannot be empty.");
                return;
            }

            // Check if book already exists
            if (dbService.GetBookByISBN(isbn) != null)
            {
                Console.WriteLine("A book with this ISBN already exists.");
                return;
            }

            Console.Write("Enter Title: ");
            string title = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Enter Author Name: ");
            string authorName = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Enter Publication Year: ");
            if (!int.TryParse(Console.ReadLine(), out int year) || year < 1000 || year > DateTime.Now.Year)
            {
                Console.WriteLine("Invalid year. Please enter a valid year.");
                return;
            }

            var book = new Book
            {
                ISBN = isbn,
                Title = title,
                AuthorName = authorName,
                PublicationYear = year
            };

            if (dbService.AddBook(book))
            {
                Console.WriteLine("Book added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add book.");
            }
        }

        static void ViewAllBooks()
        {
            Console.WriteLine("\n=== All Books ===");
            var books = dbService.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books found in the library.");
                return;
            }

            Console.WriteLine($"Total books: {books.Count}\n");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        static void SearchBook()
        {
            Console.WriteLine("\n=== Search Book ===");
            Console.Write("Enter ISBN to search: ");
            string isbn = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(isbn))
            {
                Console.WriteLine("ISBN cannot be empty.");
                return;
            }

            var book = dbService.GetBookByISBN(isbn);
            if (book != null)
            {
                Console.WriteLine("\nBook found:");
                Console.WriteLine(book);
                Console.WriteLine($"Created: {book.CreatedAt:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine($"Updated: {book.UpdatedAt:yyyy-MM-dd HH:mm:ss}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void UpdateBook()
        {
            Console.WriteLine("\n=== Update Book ===");
            Console.Write("Enter ISBN of book to update: ");
            string isbn = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(isbn))
            {
                Console.WriteLine("ISBN cannot be empty.");
                return;
            }

            var existingBook = dbService.GetBookByISBN(isbn);
            if (existingBook == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine($"\nCurrent book details:");
            Console.WriteLine(existingBook);
            Console.WriteLine("\nEnter new details (press Enter to keep current value):");

            Console.Write($"Title [{existingBook.Title}]: ");
            string newTitle = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(newTitle))
                existingBook.Title = newTitle;

            Console.Write($"Author [{existingBook.AuthorName}]: ");
            string newAuthor = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(newAuthor))
                existingBook.AuthorName = newAuthor;

            Console.Write($"Year [{existingBook.PublicationYear}]: ");
            string yearInput = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(yearInput) && int.TryParse(yearInput, out int newYear))
            {
                if (newYear >= 1000 && newYear <= DateTime.Now.Year)
                    existingBook.PublicationYear = newYear;
                else
                    Console.WriteLine("Invalid year, keeping current value.");
            }

            if (dbService.UpdateBook(existingBook))
            {
                Console.WriteLine("Book updated successfully!");
            }
            else
            {
                Console.WriteLine("Failed to update book.");
            }
        }

        static void DeleteBook()
        {
            Console.WriteLine("\n=== Delete Book ===");
            Console.Write("Enter ISBN of book to delete: ");
            string isbn = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(isbn))
            {
                Console.WriteLine("ISBN cannot be empty.");
                return;
            }

            var book = dbService.GetBookByISBN(isbn);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.WriteLine($"\nBook to delete:");
            Console.WriteLine(book);
            Console.Write("\nAre you sure you want to delete this book? (y/N): ");

            string confirmation = Console.ReadLine()?.Trim().ToLower() ?? "";
            if (confirmation == "y" || confirmation == "yes")
            {
                if (dbService.DeleteBook(isbn))
                {
                    Console.WriteLine("Book deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to delete book.");
                }
            }
            else
            {
                Console.WriteLine("Delete operation cancelled.");
            }
        }
    }
}