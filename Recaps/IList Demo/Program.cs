using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== IList<T> Basic Operations ===\n");

            // 1. Basic IList operations
            IList<string> fruits = new List<string>();

            // Add items
            fruits.Add("Apple");
            fruits.Add("Banana");
            fruits.Add("Orange");

            Console.WriteLine("Basic Operations:");
            Console.WriteLine($"Count: {fruits.Count}");
            Console.WriteLine($"First item: {fruits[0]}");
            Console.WriteLine($"Last item: {fruits[fruits.Count - 1]}");

            // 2. IList Properties
            Console.WriteLine("\nIList Properties:");
            Console.WriteLine($"Count: {fruits.Count}");
            Console.WriteLine($"IsReadOnly: {fruits.IsReadOnly}");

            // 3. IList Methods - Indexer access
            Console.WriteLine("\nIndexer Access:");
            for (int i = 0; i < fruits.Count; i++)
            {
                Console.WriteLine($"Index {i}: {fruits[i]}");
            }

            // Modify by index
            fruits[1] = "Blueberry";
            Console.WriteLine($"After changing index 1: {fruits[1]}");

            // 4. IList Methods - Insert and Remove
            Console.WriteLine("\nInsert and Remove:");
            
            // Insert at specific position
            fruits.Insert(1, "Grape");
            Console.WriteLine("After Insert(1, 'Grape'):");
            PrintList(fruits);

            // Remove by value
            fruits.Remove("Orange");
            Console.WriteLine("After Remove('Orange'):");
            PrintList(fruits);

            // Remove by index
            fruits.RemoveAt(0);
            Console.WriteLine("After RemoveAt(0):");
            PrintList(fruits);

            // 5. IList Methods - Search operations
            Console.WriteLine("\nSearch Operations:");
            fruits.Add("Apple");
            fruits.Add("Grape");

            Console.WriteLine($"IndexOf('Grape'): {fruits.IndexOf("Grape")}");
            Console.WriteLine($"Contains('Apple'): {fruits.Contains("Apple")}");
            Console.WriteLine($"Contains('Mango'): {fruits.Contains("Mango")}");

            // 6. IList Methods - Collection operations
            Console.WriteLine("\nCollection Operations:");
            
            // CopyTo
            string[] fruitArray = new string[fruits.Count];
            fruits.CopyTo(fruitArray, 0);
            Console.WriteLine($"CopyTo array: [{string.Join(", ", fruitArray)}]");

            // Clear
            IList<string> tempList = new List<string>(fruits);
            tempList.Clear();
            Console.WriteLine($"After Clear(), count: {tempList.Count}");

            // 7. IList with different implementations
            Console.WriteLine("\nDifferent IList Implementations:");
            
            // List<T>
            IList<int> list = new List<int> { 1, 2, 3 };
            Console.WriteLine($"List: [{string.Join(", ", list)}]");
            
            // Array (implements IList)
            IList<int> array = new int[] { 4, 5, 6 };
            Console.WriteLine($"Array: [{string.Join(", ", array)}]");
            Console.WriteLine($"Array IsReadOnly: {array.IsReadOnly}");

            // 8. LINQ Extension Methods on IList
            Console.WriteLine("\nLINQ Methods on IList:");
            IList<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine($"Even numbers: [{string.Join(", ", evenNumbers)}]");
            
            var squaredNumbers = numbers.Select(n => n * n);
            Console.WriteLine($"Squared: [{string.Join(", ", squaredNumbers)}]");
            
            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine($"Average: {numbers.Average():F2}");
            Console.WriteLine($"Max: {numbers.Max()}");
            Console.WriteLine($"Any > 5: {numbers.Any(n => n > 5)}");

            // 9. Custom IList implementation
            Console.WriteLine("\nCustom IList Implementation:");
            var customList = new SimpleList<string>();
            customList.Add("Custom1");
            customList.Add("Custom2");
            customList.Add("Custom3");

            Console.WriteLine("Custom list contents:");
            for (int i = 0; i < customList.Count; i++)
            {
                Console.WriteLine($"  [{i}]: {customList[i]}");
            }

            Console.WriteLine($"IndexOf('Custom2'): {customList.IndexOf("Custom2")}");
        }

        static void PrintList<T>(IList<T> list)
        {
            Console.WriteLine($"  [{string.Join(", ", list)}]");
        }
    }

    // Simple custom IList implementation
    public class SimpleList<T> : IList<T>
    {
        private T[] items;
        private int count;

        public SimpleList()
        {
            items = new T[4];
            count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();
                items[index] = value;
            }
        }

        public int Count => count;
        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (count == items.Length)
                Array.Resize(ref items, items.Length * 2);
            items[count++] = item;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();
            
            if (count == items.Length)
                Array.Resize(ref items, items.Length * 2);
            
            Array.Copy(items, index, items, index + 1, count - index);
            items[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            
            Array.Copy(items, index + 1, items, index, count - index - 1);
            count--;
            items[count] = default(T);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (Equals(items[i], item))
                    return i;
            }
            return -1;
        }

        public bool Contains(T item) => IndexOf(item) >= 0;

        public void Clear()
        {
            Array.Clear(items, 0, count);
            count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return items[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}