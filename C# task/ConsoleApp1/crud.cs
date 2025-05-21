using System;
using System.Linq.Expressions;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;

namespace Crud
{
public interface IAsset
{
    void AddAsset();
    void ViewAsset();
    void UpdateAsset();
    void DeleteAsset();
    void SearchAsset();
}


    public class Program : IAsset
    {
        static string connStr = "server = localhost; user = root; database = d; password = root; port = 3306";

        public void AddAsset()
        {
            Console.WriteLine("Enter Asset Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter date of purchase");
            DateTime dateOfPurchase = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter price");
            double price = double.Parse(Console.ReadLine());
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand("INSERT INTO ASSET_MANAGEMENT(ASSEST_NAME,ASSET_DESC,P_DATE,P_PRICE) VALUES(@name,@description,@dateOfPurchase,@price)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@dateOfPurchase", dateOfPurchase);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Asset Added");

        }
        public void ViewAsset()
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM ASSET_MANAGEMENT", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"\nID:{reader["ID"]},Name:{reader["ASSEST_NAME"]},Description:{reader["ASSET_DESC"]},DateOfPurchase:{reader["P_DATE"]},Price:{reader["P_PRICE"]}\n");
            }
        }
        public void UpdateAsset()
        {
            Console.WriteLine("Enter ID to update");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Asset Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter date of purchase");
            DateTime dateOfPurchase = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter price");
            double price = double.Parse(Console.ReadLine());
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand("UPDATE ASSET_MANAGEMENT SET ASSEST_NAME = @name, ASSET_DESC =@description, P_DATE = @dateOfPurchase, P_PRICE = @price WHERE ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@dateOfPurchase", dateOfPurchase);
            cmd.Parameters.AddWithValue("@price", price);
            int rowsaffected = cmd.ExecuteNonQuery();
            if (rowsaffected > 0)
            {
                Console.WriteLine("Asset Updated");
            }
            else
            {
                Console.WriteLine("Update failed !!!!");
            }
        }


        public void DeleteAsset()
        {
            Console.WriteLine("Enter id to delete");
            int id = int.Parse(Console.ReadLine());
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand("DELETE FROM ASSET_MANAGEMENT WHERE ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            int rowsaffected = cmd.ExecuteNonQuery();
            if (rowsaffected > 0)
            {
                Console.WriteLine("Asset Deleted");
            }
            else
            {
                Console.WriteLine("No id found");
            }
        }
        public void SearchAsset()
        {
            Console.WriteLine("Enter id to search");
            int id = int.Parse(Console.ReadLine());
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM ASSET_MANAGEMENT WHERE ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"\nID:{reader["ID"]},Name:{reader["ASSEST_NAME"]},Description:{reader["ASSET_DESC"]},DateOfPurchase:{reader["P_DATE"]},Price:{reader["P_PRICE"]}\n");
                }
            }
            else
            {
                Console.WriteLine("Asset not found");
            }
        }


    }
}

   

   
  

