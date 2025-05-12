namespace LibraryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();

            while (true)
            {
                Console.WriteLine("\n========================");
                Console.WriteLine("Library Management System");
                Console.WriteLine("========================");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Member");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Display Available Books");
                Console.WriteLine("6. Display Borrowed Books");
                Console.WriteLine("7. Display Members");
                Console.WriteLine("0. Exit");
                Console.WriteLine("========================");
                Console.Write("Select an option: ");
                if (!int.TryParse(Console.ReadLine(), out var option) || option < 0 || option > 7)
                {
                    Console.WriteLine("\nInvalid option, please try again.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\n========================");
                        Console.Write("Enter book title: ");
                        library.AddBook(new Book(Console.ReadLine() ?? string.Empty));
                        Console.WriteLine("========================");
                        break;
                    case 2:
                        Console.WriteLine("\n========================");
                        Console.Write("Enter member name: ");
                        library.AddMember(new Member(Console.ReadLine() ?? string.Empty));
                        Console.WriteLine("========================");
                        break;
                    case 3:
                        library.DisplayAvailableBooks();
                        Console.WriteLine("\n========================");
                        Console.Write("Enter member name: ");
                        var memberName = Console.ReadLine();
                        Console.Write("Enter book title: ");
                        var bookTitle = Console.ReadLine();
                        library.BorrowBook(memberName ?? string.Empty, bookTitle ?? string.Empty);
                        Console.WriteLine("========================");
                        break;
                    case 4:
                        Console.WriteLine("\n========================");
                        Console.Write("Enter member name: ");
                        memberName = Console.ReadLine();
                        Console.Write("Enter book title: ");
                        bookTitle = Console.ReadLine();
                        library.ReturnBook(memberName ?? string.Empty, bookTitle ?? string.Empty);
                        Console.WriteLine("========================");
                        break;
                    case 5:
                        library.DisplayAvailableBooks();
                        break;
                    case 6:
                        library.DisplayBorrowedBooks();
                        break;
                    case 7:
                        library.DisplayMembers();
                        break;
                    case 0:
                        Console.WriteLine("\n========================\nExiting...\n========================");
                        return;
                }
            }
        }
    }

    record Book(string Title, bool IsAvailable = true);
    record Member(string Name);

    class Library
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"\nBook '{book.Title}' added.");
        }

        public void AddMember(Member member)
        {
            members.Add(member);
            Console.WriteLine($"\nMember '{member.Name}' added.");
        }

        public void BorrowBook(string memberName, string bookTitle)
        {
            var book = books.Find(b => b.Title == bookTitle && b.IsAvailable);
            var member = members.Find(m => m.Name == memberName);

            if (book != null && member != null)
            {
                books[books.IndexOf(book)] = book with { IsAvailable = false };
                Console.WriteLine($"\nBook '{bookTitle}' borrowed by '{memberName}'.");
            }
            else
            {
                Console.WriteLine("\nBook is not available or member not found.");
            }
        }

        public void ReturnBook(string memberName, string bookTitle)
        {
            var book = books.Find(b => b.Title == bookTitle && !b.IsAvailable);
            var member = members.Find(m => m.Name == memberName);

            if (book != null && member != null)
            {
                books[books.IndexOf(book)] = book with { IsAvailable = true };
                Console.WriteLine($"\nBook '{bookTitle}' returned by '{memberName}'.");
            }
            else
            {
                Console.WriteLine("\nBook is not borrowed or member not found.");
            }
        }

        public void DisplayAvailableBooks()
        {
            bool flag = false;
            if (books.Count == 0)
            {
                Console.WriteLine("\n========================\nNo books available. Please add books.\n========================");
            }
            else
            {
                Console.WriteLine("\n========================\nAvailable Books:");
                foreach (var book in books)
                {
                    if (book.IsAvailable)
                    {
                        Console.WriteLine(book.Title);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("No books available.");
                }
                Console.WriteLine("========================");
            }
        }

        public void DisplayBorrowedBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("\n========================\nNo books available. Please add books.\n========================");
            }
            else
            {
                bool flag = false;
                Console.WriteLine("\n========================\nBorrowed Books:");
                foreach (var book in books)
                {
                    if (!book.IsAvailable)
                    {
                        Console.WriteLine(book.Title);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("No books borrowed.");
                }
                Console.WriteLine("========================");
            }

        }

        public void DisplayMembers()
        {
            Console.WriteLine("\n========================\nMembers:");
            foreach (var member in members)
            {
                Console.WriteLine(member.Name);
            }
            Console.WriteLine("========================");
        }
    }
}

