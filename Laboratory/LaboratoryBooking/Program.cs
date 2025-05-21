using System;
using MySql.Data.MySqlClient;

class LaboratoryBooking
{
    static string conn = "server=localhost;user=root;password=123;database=Laboratory;port=3306;sslmode=none";

    public static void AddEquipment()
    {
        Console.WriteLine("Enter the requested details to add equipment");
        Console.WriteLine("===========================================");
        Console.WriteLine("Enter the Equipment Name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the Price");
        decimal price = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter the Description");
        string description = Console.ReadLine();
        Console.WriteLine("Enter the Equipment Type");
        string type = Console.ReadLine();

        MySqlConnection con = new MySqlConnection(conn);
        con.Open();
        MySqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "insert into Equipment(EquipmentName,Price,Description,EquipmentType) values(@name,@price,@description,@type)";
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.Parameters.AddWithValue("@type", type);
        cmd.ExecuteNonQuery();
        con.Close();
        Console.WriteLine("Equipment added successfully");
        Console.WriteLine("===========================================");


    }
  public static void SearchByID()
    {
        Console.WriteLine("Searching Process");
        Console.WriteLine("===========================================");
        Console.WriteLine("Enter the ID");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Searching..............................");
        MySqlConnection con = new MySqlConnection(conn);
        con.Open();
        MySqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "select * from Equipment where EquipmentID=@id";
        cmd.Parameters.AddWithValue("@id", id);
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Console.WriteLine("Equipment ID: " + reader["EquipmentID"]);
            Console.WriteLine("Equipment Name: " + reader["EquipmentName"]);
            Console.WriteLine("Price: " + reader["Price"]);
            Console.WriteLine("Description: " + reader["Description"]);
            Console.WriteLine("Equipment Type: " + reader["EquipmentType"]);
            Console.WriteLine("===========================================");
        }

        else
        {
            Console.WriteLine("Equipment with ID " + id + " is not found");
            Console.WriteLine("===========================================");
        }
        con.Close();
    }
    public static void UpdateById()
    {
        Console.WriteLine("Updating Process");
        Console.WriteLine("===========================================");
        Console.WriteLine("Enter the ID");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the Equipment Name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the Price");
        decimal price = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter the Description");
        string description = Console.ReadLine();
        Console.WriteLine("Enter the Equipment Type");
        string type = Console.ReadLine();

        MySqlConnection con = new MySqlConnection(conn);
        con.Open();
        MySqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "update Equipment set EquipmentName=@name,Price=@price,Description=@description,EquipmentType=@type where EquipmentID=@id";
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@price", price);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.Parameters.AddWithValue("@type", type);
        cmd.Parameters.AddWithValue("@id", id);
        int result = cmd.ExecuteNonQuery();
        if (result == 0)
        {
            Console.WriteLine("Equipment with ID " + id + " is not found");
            Console.WriteLine("===========================================");
        }
        else
        {
            Console.WriteLine("Equipment updated successfully");
            Console.WriteLine("===========================================");
        }
        con.Close();
    }
    public static void DeleteById()
    {
        Console.WriteLine("Deleting Process");
        Console.WriteLine("===========================================");
        Console.WriteLine("Enter the ID");
        int id = int.Parse(Console.ReadLine());
    
        MySqlConnection con = new MySqlConnection(conn);
        con.Open();
        MySqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "delete from Equipment where EquipmentID=@id";
        cmd.Parameters.AddWithValue("@id", id);
        int result = cmd.ExecuteNonQuery();
        if (result == 0)
        {
            Console.WriteLine("Equipment with ID " + id + " is not found");
            Console.WriteLine("===========================================");
        }
        else
        {
            Console.WriteLine("Equipment deleted successfully");
            Console.WriteLine("===========================================");
        }
        con.Close();
    }
    public static void DisplayAll()
    {
        MySqlConnection con = new MySqlConnection(conn);
        con.Open();
        MySqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "select * from Equipment";
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Equipment ID: " + reader["EquipmentID"]);
                Console.WriteLine("Equipment Name: " + reader["EquipmentName"]);
                Console.WriteLine("Price: " + reader["Price"]);
                Console.WriteLine("Description: " + reader["Description"]);
                Console.WriteLine("Equipment Type: " + reader["EquipmentType"]);
                Console.WriteLine("---------------------------------------");
            }
            Console.WriteLine("===========================================");
        }
        else
        {
            Console.WriteLine("No records found in the database");
            Console.WriteLine("===========================================");
        }
        con.Close();
    }
   }
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Laboratory Equipment Booking System");
        Console.WriteLine("===========================================");
        while (true)
        {
            Console.WriteLine("1.AddEquipment\n2.SearchByID\n3.UpdateById\n4.DeleteById\n5.DisplayAll\n6.Exit");
            Console.WriteLine("Enter your choice");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    LaboratoryBooking.AddEquipment();
                    break;
                case 2:
                    LaboratoryBooking.SearchByID();
                    break;
                case 3:
                    LaboratoryBooking.UpdateById();
                    break;
                case 4:
                    LaboratoryBooking.DeleteById();
                    break;
                case 5:
                    LaboratoryBooking.DisplayAll();
                    break;
                case 6:
                 Console.WriteLine("Thank you for using Laboratory Equipment Booking System");
                    Console.WriteLine("===========================================");
                    Console.WriteLine(":)");
                    Environment.Exit(0);
                   
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    Console.WriteLine("===========================================");
                    break;
            }
        }
    }
}

