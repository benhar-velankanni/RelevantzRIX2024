using System;
using MySql.Data.MySqlClient;
using System.IO;

namespace Scedule
{
    public class ScheduleMain
    {
        static string connStr = "server=localhost;user=root;Password=123;database=Home_Cleaning;port=3306";

        public static void AddSchedule()
        {
            try
            {
                Console.Write("Enter Schedule ID: ");
                int scheduleId = int.Parse(Console.ReadLine());
                Console.Write("Date (yyyy-mm-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Time Slot (hh:mm): ");
                TimeSpan timeSlot = TimeSpan.Parse(Console.ReadLine());
                Console.Write("Cleaner ID: ");
                int cleanerId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();
                
                var cmd = new MySqlCommand("INSERT INTO Schedule (id, date, time_slot, cleaner_id) VALUES (@scheduleId, @date, @timeSlot, @cleanerId)", conn);
                cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@timeSlot", timeSlot);
                cmd.Parameters.AddWithValue("@cleanerId", cleanerId);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Schedule added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void ViewSchedules()
        {
            try
            {
                Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            SCHEDULES                                                                                               |");
                Console.WriteLine("+===================================================================================================================================================+");
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                
                var cmd = new MySqlCommand("SELECT id, date, time_slot, cleaner_id FROM Schedule", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}");
                    Console.WriteLine($"Date: {reader["date"]}");
                    Console.WriteLine($"Time Slot: {reader["time_slot"]}");
                    Console.WriteLine($"Cleaner ID: {reader["cleaner_id"]}");
                    Console.WriteLine();
                }
                Console.WriteLine("+===================================================================================================================================+\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void UpdateSchedule()
        {
            try
            {
                Console.Write("Enter Schedule ID to update: ");
                int scheduleId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM Schedule WHERE id=@scheduleId", conn);
                checkCmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Schedule not found.");
                    return;
                }

                Console.Write("New Date (yyyy-mm-dd): ");
                DateTime newDate = DateTime.Parse(Console.ReadLine());
                Console.Write("New Time Slot (hh:mm): ");
                TimeSpan newTimeSlot = TimeSpan.Parse(Console.ReadLine());
                Console.Write("New Cleaner ID: ");
                int newCleanerId = int.Parse(Console.ReadLine());

                var cmd = new MySqlCommand("UPDATE Schedule SET date=@newDate, time_slot=@newTimeSlot, cleaner_id=@newCleanerId WHERE id=@scheduleId", conn);
                cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                cmd.Parameters.AddWithValue("@newDate", newDate);
                cmd.Parameters.AddWithValue("@newTimeSlot", newTimeSlot);
                cmd.Parameters.AddWithValue("@newCleanerId", newCleanerId);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Schedule updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void DeleteSchedule()
        {
            try
            {
                Console.Write("Enter Schedule ID to delete: ");
                int scheduleId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM Schedule WHERE id=@scheduleId", conn);
                checkCmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Schedule not found.");
                    return;
                }

                var cmd = new MySqlCommand("DELETE FROM Schedule WHERE id=@scheduleId", conn);
                cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Schedule deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

