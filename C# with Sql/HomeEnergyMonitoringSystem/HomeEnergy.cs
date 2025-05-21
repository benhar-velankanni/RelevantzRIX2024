
using System;
using MySql.Data.MySqlClient;

namespace HomeEnergyMonitoringSystem
{
    public class HomeEnergy
    {
        static string connStr = "server=localhost;user=root;password=Mary Pushpam12@;database=Home_energy_monitoring_system;port=3306";

        public static void AddData()
        {
            Console.WriteLine("Enter the data to be added");
            Console.WriteLine("Enter the appliance Name");
            string applianceName = Console.ReadLine();
            Console.WriteLine("Enter the usage log");
            string usageLog = Console.ReadLine();
            Console.WriteLine("Enter the user name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter the energy report");
            string energyReport = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Appliances (Appliance_name, Usage_log, User_name, Energy_report) VALUES (@applianceName, @usageLog, @userName, @energyReport)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@applianceName", applianceName);
                    cmd.Parameters.AddWithValue("@usageLog", usageLog);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@energyReport", energyReport);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Data added successfully");
                    Console.WriteLine("===================================================================================");
                }
            }

        }
        public static void DisplayAllData()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Appliances";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Id: " + reader["Id"]);
                            Console.WriteLine("Appliance Name: " + reader["Appliance_name"]);
                            Console.WriteLine("Usage Log: " + reader["Usage_log"]);
                            Console.WriteLine("User Name: " + reader["User_name"]);
                            Console.WriteLine("Energy Report: " + reader["Energy_report"]);
                            Console.WriteLine();
                            Console.WriteLine("===================================================================================");

                        }
                    }
                }
            }
        }
        public static void DeleteData()
        {
            Console.WriteLine("Enter the id to be deleted");
            int id = Convert.ToInt32(Console.ReadLine());
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM Appliances WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Data deleted successfully");
                    Console.WriteLine("===================================================================================");
                }
            }
        }
        public static void UpdateData()
        {
            Console.WriteLine("Enter the id to be updated");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the data to be updated");
            Console.WriteLine("Enter the appliance Name");
            string applianceName = Console.ReadLine();
            Console.WriteLine("Enter the usage log");
            string usageLog = Console.ReadLine();
            Console.WriteLine("Enter the user name");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter the energy report");
            string energyReport = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE Appliances SET Appliance_name = @applianceName, Usage_log = @usageLog, User_name = @userName, Energy_report = @energyReport WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@applianceName", applianceName);
                    cmd.Parameters.AddWithValue("@usageLog", usageLog);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@energyReport", energyReport);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Data updated successfully");
                    Console.WriteLine("===================================================================================");
                }
            }
        }
        public static void SearchData()
        {
            Console.WriteLine("Enter the id to be searched");
            int id = Convert.ToInt32(Console.ReadLine());
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Appliances WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Id: " + reader["Id"]);
                            Console.WriteLine("Appliance Name: " + reader["Appliance_name"]);
                            Console.WriteLine("Usage Log: " + reader["Usage_log"]);
                            Console.WriteLine("User Name: " + reader["User_name"]);
                            Console.WriteLine("Energy Report: " + reader["Energy_report"]);
                            Console.WriteLine();
                            Console.WriteLine("===================================================================================");
                        }
                    }
                }
            }
        }
    }
   
}