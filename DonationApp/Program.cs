using System.Runtime.CompilerServices;
using MySql.Data.MySqlClient;
class Program
{
    static string connStr = "server=localhost;user=root;password=root;database=communitydb";
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nEnter the option");
            Console.WriteLine("1. Add Donor");
            Console.WriteLine("2. View Donors");
            Console.WriteLine("3. Update Donors");
            Console.WriteLine("4. Delete Donors");
            Console.WriteLine("5. Search Donors");
            Console.WriteLine("6. Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddDonor();
                    break;
                case 2:
                    ViewDonor();
                    break;
                case 3:
                    UpdateDonor();
                    break;
                case 4:
                    DeleteDonor();
                    break;
                case 5:
                    SearchDonor();
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
    static void AddDonor()
    {
        Console.WriteLine("Enter the Donor Name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the donation item");
        string item = Console.ReadLine();
        Console.WriteLine("Enter the NGO");
        string ngo = Console.ReadLine();
        Console.WriteLine("Enter the event");
        string event1 = Console.ReadLine();
        Console.WriteLine("Enter the status");
        bool status = bool.Parse(Console.ReadLine());
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string query = "insert into data(donor,item,ngo,event,status) values(@name,@item,@ngo,@event,@status)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@item", item);
            cmd.Parameters.AddWithValue("@ngo", ngo);
            cmd.Parameters.AddWithValue("@event", event1);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine("Donor added successfully");
        }

    }
    static void ViewDonor()
    {
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string query = "select * from data";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Id: " + reader["id"] + "  Name: " + reader["donor"] + "  Donation Item " + reader["item"] + "  NGO " + reader["ngo"] + "  Event: " + reader["event"] + "  Status: " + reader["status"]);
            }
            conn.Close();
        }
    }

    static void UpdateDonor()
    {
        Console.WriteLine("enter the donor id");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("enter the name");
        string name = Console.ReadLine();
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string query = "update data set donor=@name where id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    static void DeleteDonor()
    {
        Console.WriteLine("enter the donor id");
        int id = int.Parse(Console.ReadLine());
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string query = "delete from data where id=@id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    static void SearchDonor()
    {
        Console.WriteLine("enter the id");
        int id = int.Parse(Console.ReadLine());
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();
            string sql = "select * from data where id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Id: " + reader["id"] + "  Name: " + reader["donor"] + "  Donation Item " + reader["item"] + "  NGO " + reader["ngo"] + "  Event: " + reader["event"] + "  Status: " + reader["status"]);
            }
            conn.Close();
        }
    }
}