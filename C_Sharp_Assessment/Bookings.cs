using System;
using MySql.Data.MySqlClient;
using System.IO;

namespace Bookings
{
    public class BookingMain
    {
        static string connStr = "server=localhost;user=root;Password=123;database=Home_Cleaning;port=3306";
        

        public static void AddBooking()
        {
            try
            {
                Console.Write("Enter Booking ID: ");
                int bookingId = int.Parse(Console.ReadLine());
                Console.Write("Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                Console.Write("Service Type ID: ");
                int serviceTypeId = int.Parse(Console.ReadLine());
                Console.Write("Schedule ID: ");
                int scheduleId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();
                
                var cmd = new MySqlCommand("INSERT INTO Booking (id,customer_id, service_type_id, schedule_id) VALUES (@bookingId, @customerId, @serviceTypeId, @scheduleId)", conn);
                cmd.Parameters.AddWithValue("@bookingId", bookingId);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@serviceTypeId", serviceTypeId);
                cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Booking added.");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void ViewBookings()
        {
            try
            {
                Console.WriteLine("\n+===================================================================================================================================================+");
                Console.WriteLine("|                                            BOOKINGS                                                                                               |");
                Console.WriteLine("+===================================================================================================================================================+");
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                
                var cmd = new MySqlCommand("SELECT Booking.id, Customer.name as CustomerName, ServiceType.name as ServiceTypeName, Schedule.date, Schedule.time_slot, Cleaner.name as CleanerName FROM Booking INNER JOIN Customer ON Booking.customer_id = Customer.id INNER JOIN ServiceType ON Booking.service_type_id = ServiceType.id INNER JOIN Schedule ON Booking.schedule_id = Schedule.id INNER JOIN Cleaner ON Schedule.cleaner_id = Cleaner.id", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}");
                    Console.WriteLine($"Customer Name: {reader["CustomerName"]}");
                    Console.WriteLine($"Service Type: {reader["ServiceTypeName"]}");
                    Console.WriteLine($"Date: {reader["date"]}");
                    Console.WriteLine($"Time Slot: {reader["time_slot"]}");
                    Console.WriteLine($"Cleaner: {reader["CleanerName"]}");
                    Console.WriteLine();
                }
                Console.WriteLine("+===================================================================================================================================+\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void UpdateBooking()
        {
            try
            {
                Console.Write("Enter Booking ID to update: ");
                int bookingId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM Booking WHERE id=@bookingId", conn);
                checkCmd.Parameters.AddWithValue("@bookingId", bookingId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Booking not found.");
                    return;
                }

                Console.Write("New Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());
                Console.Write("New Service Type ID: ");
                int serviceTypeId = int.Parse(Console.ReadLine());
                Console.Write("New Schedule ID: ");
                int scheduleId = int.Parse(Console.ReadLine());

                var cmd = new MySqlCommand("UPDATE Booking SET customer_id=@customerId, service_type_id=@serviceTypeId, schedule_id=@scheduleId WHERE id=@bookingId", conn);
                cmd.Parameters.AddWithValue("@bookingId", bookingId);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@serviceTypeId", serviceTypeId);
                cmd.Parameters.AddWithValue("@scheduleId", scheduleId);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Booking updated.");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void DeleteBooking()
        {
            try
            {
                Console.Write("Enter Booking ID to delete: ");
                int bookingId = int.Parse(Console.ReadLine());

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM Booking WHERE id=@bookingId", conn);
                checkCmd.Parameters.AddWithValue("@bookingId", bookingId);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Booking not found.");
                    return;
                }

                var cmd = new MySqlCommand("DELETE FROM Booking WHERE id=@bookingId", conn);
                cmd.Parameters.AddWithValue("@bookingId", bookingId);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine("Booking deleted.");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

