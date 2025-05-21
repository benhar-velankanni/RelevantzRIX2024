using System;
using MySql.Data.MySqlClient;

namespace Crud
{
    class Program
    {
        static string connStr = "server = localhost; username = root; password = root; password = root; database = CRUD; port = 3306";

        public static void AddBill()
        {
            Console.WriteLine("Enter Bill Number");
            int billNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Participant Name :");
            string participant = Console.ReadLine();
            Console.WriteLine("Enter Expense here : ");
            double expense = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter payment status here : ");
            string paymentStatus = Console.ReadLine();
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand("INSERT INTO BILL_SPLITTER (BILL_NO,PARTICIPANT,EXPENSE,PAYMENT_STATUS) VALUES(@billNumber,@participant,@expense,@paymentStatus)", conn);
            cmd.Parameters.AddWithValue("@billNumber", billNumber);
            cmd.Parameters.AddWithValue("@participant", participant);
            cmd.Parameters.AddWithValue("@expense", expense);
            cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Bill has been added successfully");
            Console.WriteLine("----------------------------------------------");

        }
        public static void ViewAllBills()
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM BILL_SPLITTER", conn);
            using var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID : {reader["ID"]} Bill Number : {reader["BILL_NO"]} Participant : {reader["PARTICIPANT"]} Expense : {reader["EXPENSE"]} Payment Status : {reader["PAYMENT_STATUS"]}");
                }

                Console.WriteLine("All Bills have been displayed");
            }
            else
            {
                Console.WriteLine("Currently no bills found");
            }
            Console.WriteLine("--------------------------------------------");

        }

        public static void UpdateBill()
        {
            Console.WriteLine("Enter Id to update bill details");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Bill Number");
            int billNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Participant Name: ");
            string participant = Console.ReadLine();
            Console.WriteLine("Enter expense here : ");
            double expense = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter payment status here : ");
            string paymentStatus = Console.ReadLine();
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand("UPDATE BILL_SPLITTER SET BILL_NO = @billNumber, PARTICIPANT = @participant, EXPENSE =@expense, PAYMENT_STATUS = @paymentStatus WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@billNumber", billNumber);
            cmd.Parameters.AddWithValue("@participant", participant);
            cmd.Parameters.AddWithValue("@expense", expense);
            cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Bill has been updated successfully");
            }
            else
            {
                Console.WriteLine("Bill not found with the given id!! Please try with valid ID!!");
            }
            Console.WriteLine("-------------------------------------------------");
        }

        public static void DeleteBill()
        {
            Console.WriteLine("Enter ID to delete bill : ");
            int id = int.Parse(Console.ReadLine());
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand("DELETE FROM BILL_SPLITTER WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Bill has been deleted successfully");
            }
            else
            {
                Console.WriteLine("Bill not found with the given id!! Please try with valid ID!!");
            }
            Console.WriteLine("-------------------------------------------------");
        }
        public static void SearchBill()
        {
            Console.WriteLine("Enter ID to search bill : ");
            int id = int.Parse(Console.ReadLine());
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM BILL_SPLITTER WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID : {reader["ID"]} Bill Number : {reader["BILL_NO"]} Participant : {reader["PARTICIPANT"]} Expense : {reader["EXPENSE"]} Payment Status : {reader["PAYMENT_STATUS"]}");
                }
            }
            else
            {
                Console.WriteLine("ID not found!! Please try with valid ID!!");
            }
            Console.WriteLine("---------------------------------------------------");
        }
    }
}


