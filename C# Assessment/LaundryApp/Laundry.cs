using System;
using MySql.Data.MySqlClient;

namespace LaundryApp
{
    public class LaundryApp
    {
        static string connectionString = "server=localhost;user=root;Password=root;database=laundry;port=3306;";

        public static void AddItems()
        {
            Console.WriteLine("Enter the Customer name: ");
            string customerName = Console.ReadLine();

            Console.WriteLine("Enter the Service Type: ");
            string serviceType = Console.ReadLine();

            Console.WriteLine("Enter the DeliveryAgent: ");
            string DeliveryAgent = Console.ReadLine();

            Console.WriteLine("Enter the Payment: ");
            double payment = Convert.ToDouble(Console.ReadLine());

            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO laundry (CustomerName,ServiceType,DeliveryAgent,Payment) VALUES (@CustomerName,@ServiceType,@DeliveryAgent,@Payment)";
            command.Parameters.AddWithValue("@CustomerName", customerName);
            command.Parameters.AddWithValue("@ServiceType", serviceType);
            command.Parameters.AddWithValue("@DeliveryAgent", DeliveryAgent);
            command.Parameters.AddWithValue("@Payment", payment);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void ViewItems()
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM laundry";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("OrderId: " + reader["OrderId"] +"|"+ "CustomerName: " + reader["CustomerName"] +"|"+ "ServiceType: " + reader["ServiceType"] +"|"+ "DeliveryAgent: " + reader["DeliveryAgent"] +"|"+ "Payment: " + reader["Payment"]);
            }
            reader.Close();
            connection.Close();
        }

        public static void SearchItems()
        {
            Console.WriteLine("Enter the order id: ");
            int orderId = Convert.ToInt32(Console.ReadLine());
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM laundry WHERE OrderId = @OrderId";
            command.Parameters.AddWithValue("@OrderId", orderId);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("OrderId: " + reader["OrderId"] +"|"+ "CustomerName: " + reader["CustomerName"]+"|" + "ServiceType: " + reader["ServiceType"]+"|" + "DeliveryAgent: " + reader["DeliveryAgent"] +"|"+ "Payment: " + reader["Payment"]);
            }
            reader.Close();
            connection.Close();
        }

        public static void UpdateItems()
        {
            Console.WriteLine("Enter the order id: ");
            int orderId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Customer name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter the Service Type: ");
            string serviceType = Console.ReadLine();
            Console.WriteLine("Enter the DeliveryAgent: ");
            string DeliveryAgent = Console.ReadLine();
            Console.WriteLine("Enter the Payment: ");
            double payment = Convert.ToDouble(Console.ReadLine());
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE laundry SET CustomerName = @CustomerName, ServiceType = @ServiceType, DeliveryAgent = @DeliveryAgent, Payment = @Payment WHERE OrderId = @OrderId";
            command.Parameters.AddWithValue("@OrderId", orderId);
            command.Parameters.AddWithValue("@CustomerName", customerName);
            command.Parameters.AddWithValue("@ServiceType", serviceType);
            command.Parameters.AddWithValue("@DeliveryAgent", DeliveryAgent);
            command.Parameters.AddWithValue("@Payment", payment);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteItems()
        {
            Console.WriteLine("Enter the order id: ");
            int orderId = Convert.ToInt32(Console.ReadLine());
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM laundry WHERE OrderId = @OrderId";
            command.Parameters.AddWithValue("@OrderId", orderId);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}