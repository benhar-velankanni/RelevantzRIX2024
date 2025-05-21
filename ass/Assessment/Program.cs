using System;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient;

public class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1.Add Children");
            Console.WriteLine("2.Update Children");
            Console.WriteLine("3.Delete Children");
            Console.WriteLine("4.View Children");
            Console.WriteLine("5.search Children");
            Console.WriteLine("6.Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Children.insertchildren();
                    break;
                case 2:
                    Children.UpdateChildren();
                    break;
                case 3:
                    Children.DeleteChildren();
                    break;
                case 4:
                    Children.ViewChildren();
                    break;
                case 5:
                    Children.SearchChildren();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
public class Children
{
    static string connectionString = "server=localhost;user=root;password=muki19;database=ass;port=3306";

    public  static void insertchildren()
    {
        Console.WriteLine("Enter Children Name: ");
        string? name = Console.ReadLine();
        Console.WriteLine("Enter Children Age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter children affected disease: ");
        string ?disease = Console.ReadLine();
        Console.WriteLine("Enter Children Address: ");
        string? address = Console.ReadLine();
        Console.WriteLine("Enter vaccinated status");
        string? vaccinated = Console.ReadLine();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO childrens (name, age,disease,address,vaccinated_status) VALUES (@name, @age,@disease, @address, @vaccinated_status)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@disease", disease);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@vaccinated_status", vaccinated);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Children inserted successfully.");
        }
    }
    public static void UpdateChildren()
    {
        Console.Write("Enter Children ID to update: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter new Children Name: ");
        string? name = Console.ReadLine();
        Console.Write("Enter new Children Age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter new Children Disease: ");
        string? disease = Console.ReadLine();
        Console.Write("Enter new Children Address: ");
        string? address = Console.ReadLine();
        Console.WriteLine("Enter new vaccinated status");
        string vaccinated = Console.ReadLine();


        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE childrens SET name = @name, age = @age,disease = @disease, address = @address, vaccinated_status = @vaccinated_status WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@disease", disease);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@vaccinated_status", vaccinated);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Children updated successfully.");
        }
    }
    public static void DeleteChildren()
    {
        Console.Write("Enter Children ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM childrens WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Children deleted successfully.");
        }
    }
    public  static void ViewChildren()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM childrens";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Age: {reader["age"]}, Disease: {reader["disease"]}, Address: {reader["address"]}, Vaccinated Status: {reader["vaccinated_status"]}");
                        Console.WriteLine(new string('-', 100));
                    }
                }
            }
        }
    }
        
    public  static void SearchChildren()
    {
        Console.Write("Enter Children ID to search: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM childrens WHERE id = @id";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Age: {reader["age"]}, Disease: {reader["disease"]}, Address: {reader["address"]}, Vaccinated Status: {reader["vaccinated_status"]}");
                    }
                    else
                    {
                        Console.WriteLine("Children not found.");
                    }
                }
            }
        }
    }

}