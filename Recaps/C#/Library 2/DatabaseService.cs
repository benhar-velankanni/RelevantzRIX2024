using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace LibraryManagement
{
    public class DatabaseService
    {
        private readonly string connectionString = "server=localhost;user=root;password=root;database=library;port=3306";

        public bool AddBook(Book book)
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                const string sql = @"INSERT INTO books (isbn, title, author_name, publication_year) 
                                   VALUES (@isbn, @title, @authorName, @year)";

                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@isbn", book.ISBN);
                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@authorName", book.AuthorName);
                command.Parameters.AddWithValue("@year", book.PublicationYear);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
                return false;
            }
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                const string sql = "SELECT * FROM books ORDER BY title";
                using var command = new MySqlCommand(sql, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        Id = reader.GetInt32("id"),
                        ISBN = reader.GetString("isbn"),
                        Title = reader.GetString("title"),
                        AuthorName = reader.GetString("author_name"),
                        PublicationYear = reader.GetInt32("publication_year"),
                        CreatedAt = reader.GetDateTime("created_at"),
                        UpdatedAt = reader.GetDateTime("updated_at")
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving books: {ex.Message}");
            }

            return books;
        }

        public Book? GetBookByISBN(string isbn)
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                const string sql = "SELECT * FROM books WHERE isbn = @isbn";
                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@isbn", isbn);
                using var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Book
                    {
                        Id = reader.GetInt32("id"),
                        ISBN = reader.GetString("isbn"),
                        Title = reader.GetString("title"),
                        AuthorName = reader.GetString("author_name"),
                        PublicationYear = reader.GetInt32("publication_year"),
                        CreatedAt = reader.GetDateTime("created_at"),
                        UpdatedAt = reader.GetDateTime("updated_at")
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding book: {ex.Message}");
            }

            return null;
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                const string sql = @"UPDATE books 
                                   SET title = @title, author_name = @authorName, publication_year = @year 
                                   WHERE isbn = @isbn";

                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@isbn", book.ISBN);
                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@authorName", book.AuthorName);
                command.Parameters.AddWithValue("@year", book.PublicationYear);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating book: {ex.Message}");
                return false;
            }
        }

        public bool DeleteBook(string isbn)
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                const string sql = "DELETE FROM books WHERE isbn = @isbn";
                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@isbn", isbn);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting book: {ex.Message}");
                return false;
            }
        }

        public bool TestConnection()
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return false;
            }
        }
    }
}