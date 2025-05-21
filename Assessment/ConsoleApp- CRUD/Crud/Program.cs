// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


using System;
using MySql.Data.MySqlClient;
 
namespace Supply
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("=============================");
            Console.WriteLine("PEER TUTOR MANAGEMENT SYSTEM");
            Console.WriteLine("=============================");

            while (true)


            {
                Console.WriteLine("\n1. Add Details");
                Console.WriteLine("2. Display Details");
                Console.WriteLine("3. Search Details");
                Console.WriteLine("4. Update Details");
                Console.WriteLine("5. Delete Details");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Details.AddDetails();
                        break;
                    case 2:
                        Details.DisplayDetails();
                        break;
                    case 3:
                        Details.SearchDetails();
                        break;
                    case 4:
                        Details.UpdateDetails();
                        break;
                    case 5:
                        Details.DeleteDetails();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }

    class Details
    {
        static string connectionString = "server=localhost;user=root;pwd=Terrance@30;database=Crud;port=3306";

        public static void AddDetails()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Tutor Name: ");
            string tutor = Console.ReadLine();
            Console.Write("Enter the Subject: ");
            string subject = Console.ReadLine();
            Console.WriteLine("Enter the Session Details :");
            string details = Console.ReadLine();
            Console.WriteLine("Enter the Feedback :");
            string feedback = Console.ReadLine();

            using var con = new MySqlConnection(connectionString);
            con.Open();
            string query = "INSERT INTO Details(name, tutor, subject, details, feedback) VALUES(@name, @tutor, @subject, @details, @feedback)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@tutor", tutor);
            cmd.Parameters.AddWithValue("@subject", subject);
            cmd.Parameters.AddWithValue("@details", details);
            cmd.Parameters.AddWithValue("@feedback", feedback);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Details Added Successfully");
        }

           public static void DisplayDetails()
        {
            string query = "SELECT * FROM Details";
            using var con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Details of Student and Tutors");
                Console.WriteLine("====================================================================");
                Console.WriteLine($"ID: {reader["ID"]}, Student Name: {reader["name"]}, Tutor Name: {reader["tutor"]}, Subject: {reader["subject"]}, Session: {reader["details"]}, Feedback: {reader["feedback"]}");
                Console.WriteLine("================================================================");
            }
        }

        public static void SearchDetails()
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            string query = "SELECT * FROM Details WHERE ID = @ID";
            using var con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            using MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                Console.WriteLine("=======================");
                Console.WriteLine("Details Found");
                Console.WriteLine("====================================================================================");
                Console.WriteLine($"ID: {reader["ID"]}, Student Name: {reader["name"]}, Tutor Name: {reader["tutor"]}, Subject: {reader["subject"]}, Session: {reader["details"]}, Feedback: {reader["feedback"]}");
                Console.WriteLine("====================================================================================");
            }
            else
            {
                Console.WriteLine("Details not found.");
            }
        }

        public static void UpdateDetails()
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Tutor Name: ");
            string tutor = Console.ReadLine();
            Console.Write("Enter Subject: ");
            string subject = Console.ReadLine();
            Console.WriteLine("Enter the Session Details :");
            string details = Console.ReadLine();
            Console.WriteLine("Enter the Feedback :");
            string feedback = Console.ReadLine();


            string query = "UPDATE Details SET name = @name, tutor = @tutor, subject = @subject, details = @details, feedback = @feedback WHERE ID = @ID";
            using var con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@tutor", tutor);
            cmd.Parameters.AddWithValue("@subject", subject);
            cmd.Parameters.AddWithValue("@details", details);
            cmd.Parameters.AddWithValue("@feedback", feedback);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Details Updated Successfully");
        }

        public static void DeleteDetails()
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            string query = "DELETE FROM Details WHERE ID = @ID";
            using var con = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Details Deleted Successfully");
        }
    }
}

