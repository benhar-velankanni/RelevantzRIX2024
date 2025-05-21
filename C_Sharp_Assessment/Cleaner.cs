using System;
using MySql.Data.MySqlClient;
using System.IO;

namespace Cleaner
{
    public class CleanerMain
    {
        static string connStr = "server=localhost;user=root;Password=123;database=Home_Cleaning;port=3306";
        

        public static void AddCleaner()
        {
            try
            {
                Console.Write("Enter Cleaner ID: ");
                int cleanerId = int.Parse(Console.ReadLine());
                Console.Write("Cleaner Name: ");
                string cleanerName = Console.ReadLine();
                Console.Write("Cleaner Email: ");
                string cleanerEmail = Console.ReadLine();

                using var conn = new MySqlConnection(connStr);
                conn.Open();
                
                var cmd = new MySqlCommand("INSERT INTO Cleaner (id, name, email) VALUES (@cleanerId, @cleanerName, @cleanerEmail)", conn);
                cmd.Parameters.AddWithValue("@cleanerId", cleanerId);
                cmd.Parameters.AddWithValue("@cleanerName", cleanerName);
                cmd.Parameters.AddWithValue("@cleanerEmail", cleanerEmail);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Cleaner added.");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void ViewCleaners()
        {
            try
            {
                Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            CLEANERS                                                                                               |");
                Console.WriteLine("+===================================================================================================================================================+");
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                
                var cmd = new MySqlCommand("SELECT id, name, email FROM Cleaner", conn);
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

        public static void UpdateCleaner()
        {
            try
            {
                Console.Write("Enter Cleaner ID to update: ");
                int cleanerId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM Cleaner WHERE id=@cleanerId", conn);
                checkCmd.Parameters.AddWithValue("@cleanerId", cleanerId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Cleaner not found.");
                    return;
                }

                Console.Write("New Name: ");
                string newName = Console.ReadLine();
                Console.Write("New Email: ");
                string newEmail = Console.ReadLine();

                var cmd = new MySqlCommand("UPDATE Cleaner SET name=@newName, email=@newEmail WHERE id=@cleanerId", conn);
                cmd.Parameters.AddWithValue("@cleanerId", cleanerId);
                cmd.Parameters.AddWithValue("@newName", newName);
                cmd.Parameters.AddWithValue("@newEmail", newEmail);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Cleaner updated.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void DeleteCleaner()
        {
            try
            {
                Console.Write("Enter Cleaner ID to delete: ");
                int cleanerId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM Cleaner WHERE id=@cleanerId", conn);
                checkCmd.Parameters.AddWithValue("@cleanerId", cleanerId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Cleaner not found.");
                    return;
                }

                var cmd = new MySqlCommand("DELETE FROM Cleaner WHERE id=@cleanerId", conn);
                cmd.Parameters.AddWithValue("@cleanerId", cleanerId);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Cleaner deleted.");
    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

