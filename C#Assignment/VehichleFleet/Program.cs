using System;
using System.Reflection.Metadata;
using MySql.Data.MySqlClient;
public class VehichleFleetManagement
{
    static string conn = "Server=localhost;user=root;password=123;database=Vehichle;port=3306;sslmode=none";
    public void AddVehichle()
    {
        Console.WriteLine("Enter Details to add Vehichle");
        Console.WriteLine("===============================");
        Console.WriteLine("Enter Model Name");
        string ModelName = Console.ReadLine();
        Console.WriteLine("Enter Vehicle Type");
        string VehType = Console.ReadLine();
        Console.WriteLine("Enter Fuel Type");
        string Fuel = Console.ReadLine();
        Console.WriteLine("Enter Manufature Date");
        DateTime ManufactureDate = Convert.ToDateTime(Console.ReadLine());
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "INSERT INTO vehichleFleet (Model, VehichleType, FuelType,  ManufacuredYear) VALUES (@ModelName, @VehType, @Fuel, @ManufactureDate)";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@ModelName", ModelName);
        cmd.Parameters.AddWithValue("@VehType", VehType);
        cmd.Parameters.AddWithValue("@Fuel", Fuel);
        cmd.Parameters.AddWithValue("@ManufactureDate", ManufactureDate);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Vehichle Added Successfully");
        Console.WriteLine("===============================");
        con.Close();
    }
    public void DeleteById()
    {
        Console.WriteLine("Deletion Process Started");
        Console.WriteLine("===============================");
        Console.WriteLine("Enter Id");
        int VehichleID = Convert.ToInt32(Console.ReadLine());
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "DELETE FROM vehichleFleet WHERE VehichleID = @VehichleID";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@VehichleID", VehichleID);
        int rowsAffected = cmd.ExecuteNonQuery();
        if(rowsAffected == 0)
        {
            Console.WriteLine("Vehichle not found");
            Console.WriteLine("===============================");
        }
        else
        {
            Console.WriteLine("Vehichle Deleted Successfully");
            Console.WriteLine("===============================");
        }
        con.Close();
    }
    public void UpdateById()
    {
        Console.WriteLine("Update Process Started");
        Console.WriteLine("===============================");
        Console.WriteLine("Enter Id");
        int VehichleID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Model Name");
        string ModelName = Console.ReadLine();
        Console.WriteLine("Enter Vehicle Type");
        string VehType = Console.ReadLine();
        Console.WriteLine("Enter Fuel Type");
        string Fuel = Console.ReadLine();
        Console.WriteLine("Enter Manufature Date");
        DateTime ManufactureDate = Convert.ToDateTime(Console.ReadLine());
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "UPDATE vehichleFleet SET Model = @ModelName, VehichleType = @VehType, FuelType = @Fuel, ManufacuredYear = @ManufactureDate WHERE VehichleID = @VehichleID";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@VehichleID", VehichleID);
        cmd.Parameters.AddWithValue("@ModelName", ModelName);
        cmd.Parameters.AddWithValue("@VehType", VehType);
        cmd.Parameters.AddWithValue("@Fuel", Fuel);
        cmd.Parameters.AddWithValue("@ManufactureDate", ManufactureDate);
        int rowsAffected = cmd.ExecuteNonQuery();
        if(rowsAffected == 0)
        {
            Console.WriteLine("Vehichle not found");
            Console.WriteLine("===============================");
        }
        else
        {
            Console.WriteLine("Vehichle Updated Successfully");
            Console.WriteLine("===============================");
        }
        con.Close();
    }
    public void SearchById()
    {
        Console.WriteLine("Search Process Started");
        Console.WriteLine("===============================");
        Console.WriteLine("Enter Id");
        int VehichleID = Convert.ToInt32(Console.ReadLine());
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "SELECT * FROM vehichleFleet WHERE VehichleID = @VehichleID";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@VehichleID", VehichleID);
        using var reader = cmd.ExecuteReader();
        if(reader.Read())
        {
            Console.WriteLine(reader["Model"]);
            Console.WriteLine(reader["VehichleType"]);
            Console.WriteLine(reader["FuelType"]);
            Console.WriteLine(reader["ManufacuredYear"]);
        }
        else
        {
            Console.WriteLine("Vehichle not found");
            Console.WriteLine("===============================");
        }
        con.Close();
        Console.WriteLine("Vehichle Found Successfully"); 
        Console.WriteLine("===============================");

    }
    public void DisplayAllData()
    {
        Console.WriteLine("Displaying Data");
        Console.WriteLine("===============================");
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "SELECT VehichleID, Model, VehichleType, FuelType,  ManufacuredYear FROM vehichleFleet";
        using var cmd = new MySqlCommand(sql, con);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("Vehichle ID: " + reader["VehichleID"]);
            Console.WriteLine("Model: " + reader["Model"]);
            Console.WriteLine("Vehichle Type: " + reader["VehichleType"]);
            Console.WriteLine("Fuel Type: " + reader["FuelType"]);
            Console.WriteLine("Manufacured Year: " + reader["ManufacuredYear"]);
            Console.WriteLine("------------------------");
        }
        con.Close();
        Console.WriteLine("===============================");
    }
}
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            VehichleFleetManagement obj = new VehichleFleetManagement();
            Console.WriteLine("1.Add Vehichle");
            Console.WriteLine("2.Delete By Id");
            Console.WriteLine("3.Update By Id");
            Console.WriteLine("4.Search By Id");
            Console.WriteLine("5.Display All Data");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Enter Your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    obj.AddVehichle();
                    break;
                case 2:
                    obj.DeleteById();
                    break;
                case 3:
                    obj.UpdateById();
                    break;
                case 4:
                    obj.SearchById();
                    break;
                case 5:
                    obj.DisplayAllData();
                    break;
                case 6:
                Console.WriteLine("Exit Successfully");
                    Console.WriteLine("===============================");
                    Environment.Exit(0);
                    
                    break;
                case 7:
                    Console.WriteLine("Invalid Choice");
                    Console.WriteLine("===============================");
                    break;
            }
        }
    }
}