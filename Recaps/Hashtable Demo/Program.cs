using System;
using System.Collections;
using System.Collections.Generic;

namespace HashtableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Hashtable Basic Operations ===\n");

            // 1. Creating and basic operations
            Hashtable hashtable = new();

            // Adding items
            hashtable.Add("name", "John");
            hashtable.Add("age", 25);
            hashtable.Add("city", "New York");
            hashtable[123] = "Number key";  // Different key type

            Console.WriteLine("Basic Operations:");
            Console.WriteLine($"Count: {hashtable.Count}");
            Console.WriteLine($"Name: {hashtable["name"]}");
            Console.WriteLine($"Age: {hashtable["age"]}");

            // 2. Hashtable Properties
            Console.WriteLine("\nHashtable Properties:");
            Console.WriteLine($"Count: {hashtable.Count}");
            Console.WriteLine($"IsReadOnly: {hashtable.IsReadOnly}");
            Console.WriteLine($"IsFixedSize: {hashtable.IsFixedSize}");
            Console.WriteLine($"IsSynchronized: {hashtable.IsSynchronized}");

            // 3. Hashtable Methods
            Console.WriteLine("\nHashtable Methods:");

            // Contains/ContainsKey/ContainsValue
            Console.WriteLine($"Contains 'name': {hashtable.Contains("name")}");
            Console.WriteLine($"ContainsKey 'age': {hashtable.ContainsKey("age")}");
            Console.WriteLine($"ContainsValue 'John': {hashtable.ContainsValue("John")}");

            // Keys and Values
            Console.WriteLine("\nKeys:");
            foreach (object key in hashtable.Keys)
                Console.WriteLine($"  {key}");

            Console.WriteLine("Values:");
            foreach (object value in hashtable.Values)
                Console.WriteLine($"  {value}");

            // Remove
            hashtable.Remove("city");
            Console.WriteLine($"After removing 'city', count: {hashtable.Count}");

            // 4. Iteration
            Console.WriteLine("\nIteration:");
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            // 5. Clone and Clear
            Hashtable cloned = (Hashtable)hashtable.Clone();
            Console.WriteLine($"Cloned hashtable count: {cloned.Count}");

            hashtable.Clear();
            Console.WriteLine($"After Clear(), count: {hashtable.Count}");
            Console.WriteLine($"Cloned still has count: {cloned.Count}");

            // 6. Hashtable vs Dictionary comparison
            Console.WriteLine("\nHashtable vs Dictionary:");
            
            // Hashtable (non-generic, allows different types)
            Hashtable ht = new Hashtable();
            ht["string"] = "value";
            ht[1] = "number";
            ht[true] = "boolean";

            // Dictionary (generic, type-safe)
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["key1"] = "value1";
            dict["key2"] = "value2";

            Console.WriteLine("Hashtable allows mixed types:");
            foreach (DictionaryEntry entry in ht)
                Console.WriteLine($"  {entry.Key} ({entry.Key.GetType().Name}): {entry.Value}");

            Console.WriteLine("Dictionary is type-safe:");
            foreach (var kvp in dict)
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");

            // 7. Synchronized Hashtable
            Console.WriteLine("\nSynchronized Hashtable:");
            Hashtable syncHashtable = Hashtable.Synchronized(new Hashtable());
            syncHashtable["thread-safe"] = "yes";
            Console.WriteLine($"Synchronized hashtable IsSynchronized: {syncHashtable.IsSynchronized}");
        }
    }
}