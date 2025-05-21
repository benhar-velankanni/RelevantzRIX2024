using System;
using MySql.Data.MySqlClient;
using System.IO;

namespace ServiceType
{
    public class ServiceTypeMain
    {
        static string connStr = "server=localhost;user=root;Password=123;database=Home_Cleaning;port=3306";

        public static void AddServiceType()
        {
            try
            {
                Console.Write("Enter Service Type ID: ");
                int serviceTypeId = int.Parse(Console.ReadLine());
                Console.Write("Service Type Name: ");
                string serviceName = Console.ReadLine();

                using var conn = new MySqlConnection(connStr);
                conn.Open();
                
                var cmd = new MySqlCommand("INSERT INTO ServiceType (id, name) VALUES (@serviceTypeId, @serviceName)", conn);
                cmd.Parameters.AddWithValue("@serviceTypeId", serviceTypeId);
                cmd.Parameters.AddWithValue("@serviceName", serviceName);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Service Type added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void ViewServiceTypes()
        {
            try
            {
                Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            SERVICE TYPES                                                                                          |");
                Console.WriteLine("+===================================================================================================================================================+");
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                
                var cmd = new MySqlCommand("SELECT id, name FROM ServiceType", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}");
                    Console.WriteLine($"Name: {reader["name"]}");
                    Console.WriteLine();
                }
                Console.WriteLine("+===================================================================================================================================+\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void UpdateServiceType()
        {
            try
            {
                Console.Write("Enter Service Type ID to update: ");
                int serviceTypeId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM ServiceType WHERE id=@serviceTypeId", conn);
                checkCmd.Parameters.AddWithValue("@serviceTypeId", serviceTypeId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Service Type not found.");
                    return;
                }

                Console.Write("New Name: ");
                string newName = Console.ReadLine();

                var cmd = new MySqlCommand("UPDATE ServiceType SET name=@newName WHERE id=@serviceTypeId", conn);
                cmd.Parameters.AddWithValue("@serviceTypeId", serviceTypeId);
                cmd.Parameters.AddWithValue("@newName", newName);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Service Type updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void DeleteServiceType()
        {
            try
            {
                Console.Write("Enter Service Type ID to delete: ");
                int serviceTypeId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM ServiceType WHERE id=@serviceTypeId", conn);
                checkCmd.Parameters.AddWithValue("@serviceTypeId", serviceTypeId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Service Type not found.");
                    return;
                }

                var cmd = new MySqlCommand("DELETE FROM ServiceType WHERE id=@serviceTypeId", conn);
                cmd.Parameters.AddWithValue("@serviceTypeId", serviceTypeId);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Service Type deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

