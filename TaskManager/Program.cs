using System;
using MySql.Data.MySqlClient;

class Program{
    static string connectionString = "server=localhost;user=root;password=root;database=taskmanager";

    static void Main(){
        while(true){
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Update Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch(choice){
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    UpdateTask();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        }

        static void AddTask(){
            Console.Write("Enter task name: ");
            string taskName = Console.ReadLine();

            Console.Write("Enter task description: ");
            string taskDescription = Console.ReadLine();

            using(MySqlConnection connection = new MySqlConnection(connectionString)){
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO tasks (name, description) VALUES (@name, @description)", connection);
                command.Parameters.AddWithValue("@name", taskName);
                command.Parameters.AddWithValue("@description", taskDescription);
                command.ExecuteNonQuery();
                Console.WriteLine("Task added successfully");
            }
        }

        static void ViewTasks(){
            using(MySqlConnection connection = new MySqlConnection(connectionString)){
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tasks", connection);
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read()){
                    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Description: {reader["description"]}");
                }
            }
        }

        static void UpdateTask(){
            Console.Write("Enter task ID: ");
            int taskId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new task name: ");
            string taskName = Console.ReadLine();

            Console.Write("Enter new task description: ");
            string taskDescription = Console.ReadLine();

            using(MySqlConnection connection = new MySqlConnection(connectionString)){
                connection.Open();
                MySqlCommand command = new MySqlCommand("UPDATE tasks SET name = @name, description = @description WHERE id = @id", connection);
                command.Parameters.AddWithValue("@name", taskName);
                command.Parameters.AddWithValue("@description", taskDescription);
                command.Parameters.AddWithValue("@id", taskId);
                command.ExecuteNonQuery();
                Console.WriteLine("Task updated successfully");
            }
        }

        static void DeleteTask(){
            Console.Write("Enter task ID: ");
            int taskId = Convert.ToInt32(Console.ReadLine());

            using(MySqlConnection connection = new MySqlConnection(connectionString)){
                connection.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM tasks WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", taskId);
                command.ExecuteNonQuery();
                Console.WriteLine("Task deleted successfully");
            }
        }
    }
}
