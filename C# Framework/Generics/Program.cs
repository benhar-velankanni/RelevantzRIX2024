// using System;
 
// public class Program
// {
//     public static void Main(string[] args)
//     {
       
//         DataStore<string> cities = new DataStore<string>();
//         cities.Add(0, "Madurai");
//         cities.Add(1, "Chennai");
//         cities.Add(2, "Coimbatore");
 
//         Console.WriteLine("All Cities:");
//         cities.Display();
 
//         Console.WriteLine("\nCity at index 0: " + cities.Get(0));
 
//         cities.Remove(1);
//         Console.WriteLine("\nAfter removing city at index 1:");
//         cities.Display();
//     }
// }
 
// class DataStore<T>
// {
//     private T[] data = new T[2];
 
//     public void Add(int index, T item)
//     {
//         if (index >= data.Length)
//         {
//             Array.Resize(ref data, index + 1);
//         }
//         data[index] = item;
//     }
 
//     public T Get(int index)
//     {
//         if (index >= 0 && index < data.Length)
//         {
//             return data[index];
//         }
//         throw new IndexOutOfRangeException("Index out of range.");
//     }
 
//     public void Remove(int index)
//     {
//         if (index >= 0 && index < data.Length)
//         {
//             data[index] = default(T);
//         }
//     }
 
 
//     public void Display()
//     {
//         for (int i = 0; i < data.Length; i++)
//         {
//             if (data[i] != null)
//                 Console.WriteLine($"Index {i}: {data[i]}");
//         }
//     }
// }
 
 