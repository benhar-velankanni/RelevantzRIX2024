using System;
using MySql.Data.MySqlClient;

class Prescription
{
    static string connStr = "server=localhost;user=root;password=begonia@2003;database=DigitalPrescription;port=3306;SslMode=none;";

    public static void AddPrescription()
    {
        Console.WriteLine("Enter Patient Name:");
        string patientname = Console.ReadLine();
        Console.WriteLine("Enter Doctor Name:");
        string doctorname = Console.ReadLine();
        Console.WriteLine("Enter Medicine Name:");
        string medicinename = Console.ReadLine();
        Console.WriteLine("Enter Prescription Date:");
        DateTime prescriptiondate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter Total Amount:");
        double totalamount = double.Parse(Console.ReadLine());

        using var conn = new MySqlConnection(connStr);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Prescription (PatientName, DoctorName, MedicineName, Date, TotalAmount) VALUES (@patientname, @doctorname, @medicinename, @prescriptiondate, @totalamount)";
        cmd.Parameters.AddWithValue("@patientname", patientname);
        cmd.Parameters.AddWithValue("@doctorname", doctorname);
        cmd.Parameters.AddWithValue("@medicinename", medicinename);
        cmd.Parameters.AddWithValue("@prescriptiondate", prescriptiondate);
        cmd.Parameters.AddWithValue("@totalamount", totalamount);
        cmd.ExecuteNonQuery();
        conn.Close();
        Console.WriteLine("Prescription Added Successfully");
        Console.WriteLine("--------------------------------");
    }

    public static void SearchPrescription()
    {
        Console.WriteLine("Enter Prescription ID to search:");
        int id = Convert.ToInt32(Console.ReadLine());

        using var conn = new MySqlConnection(connStr);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Prescription WHERE PrescriptionID = @id";
        cmd.Parameters.AddWithValue("@id", id);
        using var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Console.WriteLine("Prescription ID: " + reader["PrescriptionID"]);
            Console.WriteLine("Patient Name: " + reader["PatientName"]);
            Console.WriteLine("Doctor Name: " + reader["DoctorName"]);
            Console.WriteLine("Medicine Name: " + reader["MedicineName"]);
            Console.WriteLine("Prescription Date: " + reader["Date"]);
            Console.WriteLine("Total Amount: " + reader["TotalAmount"]);
            Console.WriteLine("----------------------------");
        }
        else
        {
            Console.WriteLine("Prescription Not Found");
            Console.WriteLine("----------------------------");
        }
        conn.Close();
    }

    public static void UpdatePrescription()
    {
        Console.WriteLine("Enter Prescription ID to update:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter New Patient Name:");
        string patientname = Console.ReadLine();
        Console.WriteLine("Enter New Doctor Name:");
        string doctorname = Console.ReadLine();
        Console.WriteLine("Enter New Medicine Name:");
        string medicinename = Console.ReadLine();
        Console.WriteLine("Enter New Prescription Date:");
        DateTime prescriptiondate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Enter New Total Amount:");
        double totalamount = double.Parse(Console.ReadLine());

        using var conn = new MySqlConnection(connStr);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "UPDATE Prescription SET PatientName = @patientname, DoctorName = @doctorname, MedicineName = @medicinename, Date = @prescriptiondate, TotalAmount = @totalamount WHERE PrescriptionID = @id";
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@patientname", patientname);
        cmd.Parameters.AddWithValue("@doctorname", doctorname);
        cmd.Parameters.AddWithValue("@medicinename", medicinename);
        cmd.Parameters.AddWithValue("@prescriptiondate", prescriptiondate);
        cmd.Parameters.AddWithValue("@totalamount", totalamount);
        cmd.ExecuteNonQuery();
        conn.Close();
        Console.WriteLine("Prescription Updated Successfully");
        Console.WriteLine("--------------------------------");
    }

    public static void DeletePrescription()
    {
        Console.WriteLine("Enter Prescription ID to delete:");
        int id = Convert.ToInt32(Console.ReadLine());

        using var conn = new MySqlConnection(connStr);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM Prescription WHERE PrescriptionID = @id";
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        conn.Close();
        Console.WriteLine("Prescription Deleted Successfully");
        Console.WriteLine("--------------------------------");
    }

    public static void DisplayAllPrescription()
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Prescription";
        using var reader = cmd.ExecuteReader();
        if(reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Prescription ID: " + reader["PrescriptionID"]);
                Console.WriteLine("Patient Name: " + reader["PatientName"]);
                Console.WriteLine("Doctor Name: " + reader["DoctorName"]);
                Console.WriteLine("Medicine Name: " + reader["MedicineName"]);
                Console.WriteLine("Prescription Date: " + reader["Date"]);
                Console.WriteLine("Total Amount: " + reader["TotalAmount"]);
                Console.WriteLine("----------------------------");
            }
        } else{
            Console.WriteLine("No Prescription Data Found");
            Console.WriteLine("----------------------------");
        }
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("-----Digital Prescription Management System-----");
            Console.WriteLine("1. Add Prescription");
            Console.WriteLine("2. Search Prescription");
            Console.WriteLine("3. Update Prescription");
            Console.WriteLine("4. Delete Prescription");
            Console.WriteLine("5. Display All Prescriptions");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Prescription.AddPrescription();
                    break;
                case 2:
                    Prescription.SearchPrescription();
                    break;
                case 3:
                    Prescription.UpdatePrescription();
                    break;
                case 4:
                    Prescription.DeletePrescription();
                    break;
                case 5:
                    Prescription.DisplayAllPrescription();
                    break;
                case 6:
                    Console.WriteLine("-----Exiting Digital Prescription Management System-----");
                    Console.WriteLine("Thank You for using Digital Prescription Management System");
                    Console.WriteLine("-----------------------------------------------------------");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
