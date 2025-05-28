using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== IEnumerable<T> Basic Operations ===\n");

            // 1. Basic foreach iteration
            IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Basic iteration:");
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

            // 2. LINQ Extension Methods on IEnumerable
            Console.WriteLine("\nIEnumerable Extension Methods:");

            // Filtering
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine($"Where (even): {string.Join(", ", evenNumbers)}");

            // Projection
            var squaredNumbers = numbers.Select(n => n * n);
            Console.WriteLine($"Select (squared): {string.Join(", ", squaredNumbers)}");

            // Aggregation
            Console.WriteLine($"Count(): {numbers.Count()}");
            Console.WriteLine($"Sum(): {numbers.Sum()}");
            Console.WriteLine($"Average(): {numbers.Average()}");
            Console.WriteLine($"Max(): {numbers.Max()}");
            Console.WriteLine($"Min(): {numbers.Min()}");

            // Element operations
            Console.WriteLine($"First(): {numbers.First()}");
            Console.WriteLine($"Last(): {numbers.Last()}");
            Console.WriteLine($"ElementAt(2): {numbers.ElementAt(2)}");

            // Existence checks
            Console.WriteLine($"Any(n > 3): {numbers.Any(n => n > 3)}");
            Console.WriteLine($"All(n > 0): {numbers.All(n => n > 0)}");
            Console.WriteLine($"Contains(3): {numbers.Contains(3)}");

            // Conversion
            var numberArray = numbers.ToArray();
            var numberList = numbers.ToList();
            Console.WriteLine($"ToArray(): [{string.Join(", ", numberArray)}]");
            Console.WriteLine($"ToList(): [{string.Join(", ", numberList)}]");

            // 3. Custom class implementing IEnumerable
            Console.WriteLine("\nCustom IEnumerable:");
            var bookCollection = new BookCollection();
            bookCollection.AddBook("Book 1");
            bookCollection.AddBook("Book 2");
            bookCollection.AddBook("Book 3");

            foreach (string book in bookCollection)
            {
                Console.WriteLine($"- {book}");
            }

            // Using LINQ methods on custom collection
            Console.WriteLine($"Book count: {bookCollection.Count()}");
            Console.WriteLine($"First book: {bookCollection.First()}");

            Console.ReadKey();
        }
    }

    // Simple custom IEnumerable implementation
    public class BookCollection : IEnumerable<string>
    {
        private List<string> books = new List<string>();

        public void AddBook(string book)
        {
            books.Add(book);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return books.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}