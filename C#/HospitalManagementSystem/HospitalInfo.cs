using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;

public class HospitalInfo
{
    static string CONNECTION_STRING = "server=localhost;user=root;password=root;database=HospitalManagementSystem;port=3306";
    public static void adddetails()
    {
        Console.WriteLine("Enter Patient Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Patient Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Patient Fee: ");
        decimal fee = decimal.Parse(Console.ReadLine());
        using var connect = new MySqlConnection(CONNECTION_STRING);
        connect.Open();
        var cmd = new MySqlCommand("INSERT INTO hospital_info (Patient_Name,Patient_Age,Patient_Fee) VALUES (@name,@age,@fee)", connect);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@age", age);
        cmd.Parameters.AddWithValue("@fee", fee);
        cmd.ExecuteNonQuery();
    }

    public static void DisplayDetails()
    {
        using var connect = new MySqlConnection(CONNECTION_STRING);
        connect.Open();
        var cmd = new MySqlCommand("SELECT * FROM hospital_info", connect);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($" Patient Id:{reader["Patient_Id"]}\n Patient Name:{reader["Patient_Name"]}\n Patient Age:{reader["Patient_Age"]}\n Patient Fee:{reader["Patient_Fee"]}\n");
        }
    }

    public static void SearchId(int ?id)
    {
        int? ID = id;
        int pid;
        if (ID == null)
        {
            Console.WriteLine("Enter Patient Id: ");
            pid = int.Parse(Console.ReadLine());
        }
        else
        {
            pid = (int)ID;
        }
        using var Connect = new MySqlConnection(CONNECTION_STRING);
        Connect.Open();
        var cmd = new MySqlCommand("SELECT * FROM hospital_info WHERE Patient_Id=@id", Connect);
        cmd.Parameters.AddWithValue("@id", pid);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($" Patient Id:{reader["Patient_Id"]}\n Patient Name:{reader["Patient_Name"]}\n Patient Age:{reader["Patient_Age"]}\n Patient Fee:{reader["Patient_Fee"]}\n");
        }
    }

    public static void UpdateDetails()
    {
        Console.WriteLine("Enter Patient Id: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Patient Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Patient Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Patient Fee: ");
        decimal fee = decimal.Parse(Console.ReadLine());
        using var Connect = new MySqlConnection(CONNECTION_STRING);
        Connect.Open();
        var cmd = new MySqlCommand("UPDATE hospital_info SET Patient_Name=@name,Patient_Age=@age,Patient_Fee=@fee WHERE Patient_Id=@id", Connect);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@age", age);
        cmd.Parameters.AddWithValue("@fee", fee);
        cmd.Parameters.AddWithValue("@id", id);
        var rowsaffected = cmd.ExecuteNonQuery();
        if (rowsaffected > 0)
        {
            Console.WriteLine("After Updation:");
            SearchId(id);
        }
        else
        {
            Console.WriteLine("Patient Id Not Found");
        }
    }

    public static void DeleteDetails()
    {
        Console.WriteLine("Enter Patient Id: ");
        int id = int.Parse(Console.ReadLine());
        using var Connect = new MySqlConnection(CONNECTION_STRING);
        Connect.Open();
        var cmd = new MySqlCommand("DELETE FROM hospital_info WHERE Patient_Id=@id", Connect);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        Console.WriteLine("After Deletion:");
        DisplayDetails();
    }
}