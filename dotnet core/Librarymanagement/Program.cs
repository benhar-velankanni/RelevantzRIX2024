using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }
    public Member BorrowedBy { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
        IsAvailable = true;
        BorrowedBy = null;
    }

    public void Borrow(Member member)
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            BorrowedBy = member;
            Console.WriteLine($"Book '{Title}' borrowed by {member.Name}");
        }
        else
        {
            Console.WriteLine($"Book '{Title}' is not available");
        }
    }

    public void ReturnBook()
    {
        if (!IsAvailable)
        {
            IsAvailable = true;
            BorrowedBy = null;
            Console.WriteLine($"Book '{Title}' returned");
        }
        else
        {
            Console.WriteLine($"Book '{Title}' is already available");
        }
    }
}

public class Member
{
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; }

    public Member(string name)
    {
        Name = name;
        BorrowedBooks = new List<Book>();
    }

    public void BorrowBook(Book book)
    {
        book.Borrow(this);
        if (!book.IsAvailable)
        {
            BorrowedBooks.Add(book);
        }
    }

    public void ReturnBook(Book book)
    {
        book.ReturnBook();
        if (book.IsAvailable)
        {
            BorrowedBooks.Remove(book);
        }
    }
}

public class Library
{
    public List<Book> Books { get; set; }
    public List<Member> Members { get; set; }

    public Library()
    {
        Books = new List<Book>();
        Members = new List<Member>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void AddMember(Member member)
    {
        Members.Add(member);
    }

    public void DisplayBooks()
    {
        foreach (var book in Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Availability: {book.IsAvailable}");
        }
    }

    public void DisplayMembers()
    {
        foreach (var member in Members)
        {
            Console.WriteLine($"Name: {member.Name}");
            foreach (var book in member.BorrowedBooks)
            {
                Console.WriteLine($"  - {book.Title}");
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of books: ");
        int bookCount = Convert.ToInt32(Console.ReadLine());

        Book[] books = new Book[bookCount];

        for (int i = 0; i < bookCount; i++)
        {
            Console.Write($"Enter title of book {i + 1}: ");
            string title = Console.ReadLine();

            Console.Write($"Enter author of book {i + 1}: ");
            string author = Console.ReadLine();

            books[i] = new Book(title, author);
        }

        Console.Write("Enter the number of members: ");
        int memberCount = Convert.ToInt32(Console.ReadLine());

        Member[] members = new Member[memberCount];

        for (int i = 0; i < memberCount; i++)
        {
            Console.Write($"Enter name of member {i + 1}: ");
            string name = Console.ReadLine();

            members[i] = new Member(name);
        }

        while (true)
        {
            Console.WriteLine("1. Display Books");
            Console.WriteLine("2. Display Members");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    foreach (var book in books)
                    {
                        Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Availability: {book.IsAvailable}");
                    }
                    break;
                case 2:
                    foreach (var member in members)
                    {
                        Console.WriteLine($"Name: {member.Name}");
                    }
                    break;
                case 3:
                    Console.Write("Enter the title of the book to borrow: ");
                    string bookTitle = Console.ReadLine();

                    Console.Write("Enter the name of the member to borrow the book: ");
                    string memberName = Console.ReadLine();

                    var bookToBorrow = Array.Find(books, b => b.Title == bookTitle);
                    var memberToBorrow = Array.Find(members, m => m.Name == memberName);

                    if (bookToBorrow != null && memberToBorrow != null)
                    {
                        memberToBorrow.BorrowBook(bookToBorrow);
                    }
                    else
                    {
                        Console.WriteLine("Book or member not found");
                    }
                    break;
                case 4:
                    Console.Write("Enter the title of the book to return: ");
                    bookTitle = Console.ReadLine();

                    Console.Write("Enter the name of the member to return the book: ");
                    memberName = Console.ReadLine();

                    bookToBorrow = Array.Find(books, b => b.Title == bookTitle);
                    memberToBorrow = Array.Find(members, m => m.Name == memberName);

                    if (bookToBorrow != null && memberToBorrow != null)
                    {
                        memberToBorrow.ReturnBook(bookToBorrow);
                    }
                    else
                    {
                        Console.WriteLine("Book or member not found");
                    }
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}