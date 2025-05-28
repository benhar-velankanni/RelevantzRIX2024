using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Queue Basic Operations ===\n");

            // 1. Generic Queue<T>
            Console.WriteLine("Generic Queue<T>:");
            Queue<string> queue = new Queue<string>();

            // Enqueue (add to back)
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");

            Console.WriteLine($"Count: {queue.Count}");

            // Peek (look at front without removing)
            Console.WriteLine($"Peek: {queue.Peek()}");
            Console.WriteLine($"Count after Peek: {queue.Count}");

            // Dequeue (remove from front)
            Console.WriteLine($"Dequeue: {queue.Dequeue()}");
            Console.WriteLine($"Count after Dequeue: {queue.Count}");

            // 2. Queue Methods
            Console.WriteLine("\nQueue Methods:");
            
            // Contains
            Console.WriteLine($"Contains 'Second': {queue.Contains("Second")}");
            Console.WriteLine($"Contains 'First': {queue.Contains("First")}");

            // ToArray
            string[] queueArray = queue.ToArray();
            Console.WriteLine($"ToArray: [{string.Join(", ", queueArray)}]");

            // Clear
            Queue<string> tempQueue = new Queue<string>(queue);
            tempQueue.Clear();
            Console.WriteLine($"After Clear(), count: {tempQueue.Count}");

            // 3. Iteration (FIFO order)
            Console.WriteLine("\nIteration (FIFO order):");
            foreach (string item in queue)
            {
                Console.WriteLine($"  {item}");
            }

            // 4. Queue with different data types
            Console.WriteLine("\nQueue with integers:");
            Queue<int> numberQueue = new Queue<int>();
            
            for (int i = 1; i <= 5; i++)
            {
                numberQueue.Enqueue(i * 10);
                Console.WriteLine($"Enqueued: {i * 10}");
            }

            Console.WriteLine("Processing queue:");
            while (numberQueue.Count > 0)
            {
                int number = numberQueue.Dequeue();
                Console.WriteLine($"Processed: {number}");
            }

            // 5. Non-generic Queue (legacy)
            Console.WriteLine("\nNon-generic Queue:");
            Queue nonGenericQueue = new Queue();
            
            nonGenericQueue.Enqueue("String");
            nonGenericQueue.Enqueue(123);
            nonGenericQueue.Enqueue(true);

            Console.WriteLine("Mixed types in non-generic queue:");
            foreach (object item in nonGenericQueue)
            {
                Console.WriteLine($"  {item} ({item.GetType().Name})");
            }

            // 6. Queue Properties
            Console.WriteLine("\nQueue Properties:");
            Queue<string> propQueue = new Queue<string>();
            propQueue.Enqueue("Test");
            
            Console.WriteLine($"Count: {propQueue.Count}");
            Console.WriteLine($"IsSynchronized: {((ICollection)propQueue).IsSynchronized}");

            // 7. Practical example - Task processing
            Console.WriteLine("\nPractical Example - Task Processing:");
            Queue<string> taskQueue = new Queue<string>();
            
            // Add tasks
            taskQueue.Enqueue("Send Email");
            taskQueue.Enqueue("Process Payment");
            taskQueue.Enqueue("Update Database");
            taskQueue.Enqueue("Generate Report");

            Console.WriteLine("Processing tasks in FIFO order:");
            int taskNumber = 1;
            while (taskQueue.Count > 0)
            {
                string task = taskQueue.Dequeue();
                Console.WriteLine($"Task {taskNumber}: {task} - Completed");
                taskNumber++;
            }

        }
    }
}