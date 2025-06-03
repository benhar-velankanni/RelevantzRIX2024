namespace IDictionaryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== IDictionary<TKey, TValue> Basic Operations ===\n");

            // 1. Basic dictionary operations
            IDictionary<string, int> ages = new Dictionary<string, int>();

            // Adding items
            ages.Add("Alice", 25);
            ages["Bob"] = 30;  // Alternative way to add

            Console.WriteLine("Basic Operations:");
            Console.WriteLine($"Count: {ages.Count}");
            Console.WriteLine($"Alice's age: {ages["Alice"]}");

            // Safe access
            if (ages.TryGetValue("Charlie", out int charlieAge))
                Console.WriteLine($"Charlie's age: {charlieAge}");
            else
                Console.WriteLine("Charlie not found");

            // Check existence
            Console.WriteLine($"Contains Bob: {ages.ContainsKey("Bob")}");

            // Remove
            ages.Remove("Bob");
            Console.WriteLine($"After removing Bob, count: {ages.Count}");

            // 2. IDictionary Properties and Methods
            Console.WriteLine("\nIDictionary Properties:");
            Console.WriteLine($"Keys: {string.Join(", ", ages.Keys)}");
            Console.WriteLine($"Values: {string.Join(", ", ages.Values)}");
            Console.WriteLine($"IsReadOnly: {ages.IsReadOnly}");

            // 3. IDictionary Methods
            Console.WriteLine("\nIDictionary Methods:");

            // Add more items for demonstration
            ages["Charlie"] = 35;
            ages["Diana"] = 28;

            // Contains (KeyValuePair)
            var kvp = new KeyValuePair<string, int>("Alice", 25);
            Console.WriteLine($"Contains Alice-25 pair: {ages.Contains(kvp)}");

            // CopyTo
            var array = new KeyValuePair<string, int>[ages.Count];
            ages.CopyTo(array, 0);
            Console.WriteLine("Copied to array:");
            foreach (var item in array)
                Console.WriteLine($"  {item.Key}: {item.Value}");

            // Clear
            var tempDict = new Dictionary<string, int>(ages);
            tempDict.Clear();
            Console.WriteLine($"After Clear(): {tempDict.Count}");

            // 4. LINQ Extension Methods on IDictionary
            Console.WriteLine("\nLINQ Methods on IDictionary:");

            // Where
            var adults = ages.Where(kvp => kvp.Value >= 30);
            Console.WriteLine($"Adults (30+): {string.Join(", ", adults.Select(kvp => kvp.Key))}");

            // Select
            var descriptions = ages.Select(kvp => $"{kvp.Key} is {kvp.Value} years old");
            Console.WriteLine("Descriptions:");
            foreach (var desc in descriptions)
                Console.WriteLine($"  {desc}");

            // Any/All
            Console.WriteLine($"Any over 30: {ages.Any(kvp => kvp.Value > 30)}");
            Console.WriteLine($"All adults: {ages.All(kvp => kvp.Value >= 18)}");

            // ToDictionary
            var upperCaseDict = ages.ToDictionary(kvp => kvp.Key.ToUpper(), kvp => kvp.Value);
            Console.WriteLine($"Uppercase keys: {string.Join(", ", upperCaseDict.Keys)}");

            // 5. Custom IDictionary implementation
            Console.WriteLine("\nCustom IDictionary:");
            var caseInsensitiveDict = new CaseInsensitiveDictionary<int>();
            caseInsensitiveDict.Add("NAME", 100);
            caseInsensitiveDict.Add("age", 25);

            Console.WriteLine($"Access 'name' (lowercase): {caseInsensitiveDict["name"]}");
            Console.WriteLine($"Contains 'AGE': {caseInsensitiveDict.ContainsKey("AGE")}");
        }
    }

    // Simple custom IDictionary implementation
    public class CaseInsensitiveDictionary<TValue> : IDictionary<string, TValue>
    {
        private readonly Dictionary<string, TValue> innerDict;

        public CaseInsensitiveDictionary()
        {
            innerDict = new Dictionary<string, TValue>(StringComparer.OrdinalIgnoreCase);
        }

        public TValue this[string key]
        {
            get => innerDict[key];
            set => innerDict[key] = value;
        }

        public ICollection<string> Keys => innerDict.Keys;
        public ICollection<TValue> Values => innerDict.Values;
        public int Count => innerDict.Count;
        public bool IsReadOnly => false;

        public void Add(string key, TValue value) => innerDict.Add(key, value);
        public void Add(KeyValuePair<string, TValue> item) => innerDict.Add(item.Key, item.Value);
        public void Clear() => innerDict.Clear();
        public bool Contains(KeyValuePair<string, TValue> item) => innerDict.Contains(item);
        public bool ContainsKey(string key) => innerDict.ContainsKey(key);
        public void CopyTo(KeyValuePair<string, TValue>[] array, int arrayIndex) =>
            ((ICollection<KeyValuePair<string, TValue>>)innerDict).CopyTo(array, arrayIndex);
        public IEnumerator<KeyValuePair<string, TValue>> GetEnumerator() => innerDict.GetEnumerator();
        public bool Remove(string key) => innerDict.Remove(key);
        public bool Remove(KeyValuePair<string, TValue> item) =>
            ((ICollection<KeyValuePair<string, TValue>>)innerDict).Remove(item);
        public bool TryGetValue(string key, out TValue value) => innerDict.TryGetValue(key, out value);
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}