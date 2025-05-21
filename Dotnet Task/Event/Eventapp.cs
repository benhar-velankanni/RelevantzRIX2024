using System;
using MySql.Data.MySqlClient;

namespace EventApp
{
    public class Eventmanagement
    {
        static string connectionString = "server=localhost;user=root;Password=root;database=Event;port=3306";
        
        public static void AddEvent()
        {
            Console.WriteLine("Enter the event name");
            string eventName = Console.ReadLine();
            Console.WriteLine("Enter the event type");
            string eventType = Console.ReadLine();
            Console.WriteLine("Enter the date (yyyy-mm-dd hh:mm:ss)");
            string date = Console.ReadLine();
            Console.WriteLine("Enter the event venue");
            string venue = Console.ReadLine();
            Console.WriteLine("Enter the budget");
            decimal budget = Convert.ToDecimal(Console.ReadLine());

            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO eventm(EventName, EventType, Date, Venue, Budget) VALUES(@eventName, @eventType, @date, @venue, @budget)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@eventName", eventName);
            command.Parameters.AddWithValue("@eventType", eventType);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@venue", venue);
            command.Parameters.AddWithValue("@budget", budget);
            command.ExecuteNonQuery();
            Console.WriteLine("Event added successfully");
        }

        public static void ViewEvent()
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM eventm";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Event id :" +reader["EventID"] + " " +"Event Name :"+ reader["EventName"] + " " +"Event Type :"+ reader["EventType"] + " " +"Event Date :"+ reader["Date"] + " " + "Event venue :"+ reader["Venue"] + " " +"Event Budget :"+ reader["Budget"]+" ");
            }
        }

        public static void SearchEvent()
        {
            Console.WriteLine("Enter the event ID to search");
            int eventID = Convert.ToInt32(Console.ReadLine());
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM eventm WHERE EventID=@eventID";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@eventID", eventID);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Event id :" +reader["EventID"]+" "+"Event Name :"+ reader["EventName"]+" "+"Event Type :"+ reader["EventType"]+" "+"Event Date :"+ reader["Date"]+" "+"Event venue :"+ reader["Venue"]+" "+"Event Budget :"+ reader["Budget"]+" ");
            }
        }

        public static void UpdateEvent()
        {
            Console.WriteLine("Enter the event ID to update");
            int eventID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the new event name");
            string eventName = Console.ReadLine();
            Console.WriteLine("Enter the new event type");
            string eventType = Console.ReadLine();
            Console.WriteLine("Enter the new event date (yyyy-mm-dd hh:mm:ss)");
            string date = Console.ReadLine();
            Console.WriteLine("Enter the new event venue");
            string venue = Console.ReadLine();
            Console.WriteLine("Enter the new event budget");
            decimal budget = Convert.ToDecimal(Console.ReadLine());

            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "UPDATE eventm SET EventName=@eventName, EventType=@eventType, Date=@date, Venue=@venue, Budget=@budget WHERE EventID=@eventID";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@eventName", eventName);
            command.Parameters.AddWithValue("@eventType", eventType);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@venue", venue);
            command.Parameters.AddWithValue("@budget", budget);
            command.Parameters.AddWithValue("@eventID", eventID);
            command.ExecuteNonQuery();
            Console.WriteLine("Event updated successfully");
        }

        public static void DeleteEvent()
        {
            Console.WriteLine("Enter the event ID to delete");
            int eventID = Convert.ToInt32(Console.ReadLine());
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "DELETE FROM eventm WHERE EventID=@eventID";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@eventID", eventID);
            command.ExecuteNonQuery();
            Console.WriteLine("Event deleted successfully");
        }
    }
}
