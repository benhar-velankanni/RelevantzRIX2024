using System;
using MySql.Data.MySqlClient;
using System.IO;

namespace Customers
{
    public class CustomerMain
    {
        static string connStr = "server=localhost;user=root;Password=123;database=Home_Cleaning;port=3306";

        public static void AddCustomer()
        {
            try
            {
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                Console.Write("Customer Name: ");
                string customerName = Console.ReadLine();
                Console.Write("Customer Email: ");
                string customerEmail = Console.ReadLine();

                using var conn = new MySqlConnection(connStr);
                conn.Open();
                
                var cmd = new MySqlCommand("INSERT INTO Customer (id, name, email) VALUES (@customerId, @customerName, @customerEmail)", conn);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@customerName", customerName);
                cmd.Parameters.AddWithValue("@customerEmail", customerEmail);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Customer added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void ViewCustomers()
        {
            try
            {
                Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            CUSTOMERS                                                                                              |");
                Console.WriteLine("+===================================================================================================================================================+");
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                
                var cmd = new MySqlCommand("SELECT id, name, email FROM Customer", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}");
                    Console.WriteLine($"Name: {reader["name"]}");
                    Console.WriteLine($"Email: {reader["email"]}");
                    Console.WriteLine();
                }
                Console.WriteLine("+===================================================================================================================================+\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void UpdateCustomer()
        {
            try
            {
                Console.Write("Enter Customer ID to update: ");
                int customerId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM Customer WHERE id=@customerId", conn);
                checkCmd.Parameters.AddWithValue("@customerId", customerId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                Console.Write("New Name: ");
                string newName = Console.ReadLine();
                Console.Write("New Email: ");
                string newEmail = Console.ReadLine();

                var cmd = new MySqlCommand("UPDATE Customer SET name=@newName, email=@newEmail WHERE id=@customerId", conn);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@newName", newName);
                cmd.Parameters.AddWithValue("@newEmail", newEmail);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Customer updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void DeleteCustomer()
        {
            try
            {
                Console.Write("Enter Customer ID to delete: ");
                int customerId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM Customer WHERE id=@customerId", conn);
                checkCmd.Parameters.AddWithValue("@customerId", customerId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                var cmd = new MySqlCommand("DELETE FROM Customer WHERE id=@customerId", conn);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Customer deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

