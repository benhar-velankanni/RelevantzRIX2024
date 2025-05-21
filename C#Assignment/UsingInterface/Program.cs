using System;
using System.Web;
using MySql.Data.MySqlClient;
public class Vehichle
{
    public string VehModel { get; set; }
    public string VehColour { get; set; }
    public decimal VehPrice { get; set; }
    public DateTime Yera { get; set; } 
}

public interface IVehichleFleetManagent
{
    void AddVehichle(Vehichle vehichle);
    void DeleteById(int id);
    void UpdateById(int id);
    void SearchById(int id);
    void DisplayAllData();
}
public class VehichleFleetManagement : IVehichleFleetManagent
{
    static string conn = "server=localhost;uid=root;pwd=123;database=Vehichle2;port=3306;SslMode=none";
    public void AddVehichle(Vehichle vehichle)
    {
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "INSERT INTO vehichle(Model, Colour, Price,  Manufactured) VALUES (@VehModel, @VehColour, @VehPrice, @Yera)";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@VehModel", vehichle.VehModel);
        cmd.Parameters.AddWithValue("@VehColour", vehichle.VehColour);
        cmd.Parameters.AddWithValue("@VehPrice", vehichle.VehPrice);
        cmd.Parameters.AddWithValue("@Yera", vehichle.Yera);
        cmd.ExecuteNonQuery();
        con.Close();
        Console.WriteLine("Vehichle Added Successfully");
    }
    public void DeleteById(int id)
    {
        Console.WriteLine("Deletion Process Started");
        Console.WriteLine("===============================");
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "DELETE FROM vehichle WHERE ID = @ID";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@ID", id);
        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            Console.WriteLine("Vehichle not found");
        }
        else
        {
            Console.WriteLine("Vehichle Deleted Successfully");
        }
        con.Close();
    }
    public void UpdateById(int id)
    {
        Console.WriteLine("Update Process Started");
        Console.WriteLine("===============================");
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "UPDATE vehichle SET Colour = 'Red' WHERE ID = @ID";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@ID", id);
        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            Console.WriteLine("Vehichle not found");
        }
        else
        {
            Console.WriteLine("Vehichle Updated Successfully");
        }
        con.Close();
    }
    public void SearchById(int id)
    {
        Console.WriteLine("Search Process Started");
        Console.WriteLine("===============================");
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "SELECT * FROM vehichle WHERE ID = @ID";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@ID", id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Console.WriteLine(reader["Model"]);
            Console.WriteLine(reader["Colour"]);
            Console.WriteLine(reader["Price"]);
            Console.WriteLine(reader["Manufactured"]);
        }
        else
        {
            Console.WriteLine("Vehichle not found");
        }
        con.Close();
    }
    public void DisplayAllData()
    {
        Console.WriteLine("Displaying Data");
        Console.WriteLine("===============================");
        using var con = new MySqlConnection(conn);
        con.Open();
        string sql = "SELECT ID, Model, Colour, Price, Manufactured FROM vehichle";
        using var cmd = new MySqlCommand(sql, con);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine("ID: " + reader["ID"]);
            Console.WriteLine("Model: " + reader["Model"]);
            Console.WriteLine("Colour: " + reader["Colour"]);
            Console.WriteLine("Price: " + reader["Price"]);
            Console.WriteLine("Manufactured: " + reader["Manufactured"]);
            Console.WriteLine("------------------------");
        }
        con.Close();
        Console.WriteLine("===============================");
    }
}   
class Program
    {
    static void Main(string[] args) {
        IVehichleFleetManagent vehichleFleetManagement = new VehichleFleetManagement();
        while (true)
        {
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
                    Vehichle vehichle = new Vehichle();
                    Console.WriteLine("Enter Model");
                    vehichle.VehModel = Console.ReadLine();
                    Console.WriteLine("Enter Colour");
                    vehichle.VehColour = Console.ReadLine();
                    Console.WriteLine("Enter Price");
                    vehichle.VehPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter Yera");
                    vehichle.Yera = Convert.ToDateTime(Console.ReadLine());
                    vehichleFleetManagement.AddVehichle(vehichle);
                    break;
                case 2:
                    Console.WriteLine("Enter Id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    vehichleFleetManagement.DeleteById(id);
                    break;
                case 3:
                    Console.WriteLine("Enter Id");
                    id = Convert.ToInt32(Console.ReadLine());
                    vehichleFleetManagement.UpdateById(id);
                    break;
                case 4:
                    Console.WriteLine("Enter Id");
                    id = Convert.ToInt32(Console.ReadLine());
                    vehichleFleetManagement.SearchById(id);
                    break;
                case 5:
                    vehichleFleetManagement.DisplayAllData();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
    }