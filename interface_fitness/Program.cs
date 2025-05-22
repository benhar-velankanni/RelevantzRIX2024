// Interface Fitness Tracking

using System;
using System.Diagnostics;
using MySql.Data.MySqlClient;

public class FitnessTrackingEntry
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public DateTime JoinedDate { get; set; }
    public int NoOfSteps { get; set; }
    public string WorkoutType { get; set; }
    public double CaloriesBurned { get; set; }
}

public interface IFitnessTrackingManagement
{
    void AddEntry(FitnessTrackingEntry entry);
    void DeleteById(int id);
    void UpdateById(int id);
    void SearchById(int id);
    void DisplayAllData();
}

public class FitnessTrackingManagement : IFitnessTrackingManagement
{
    static string connStr = "server=localhost;uid=root;pwd=Reset@123;database=fitness;port=3306;SslMode=none";

    public void AddEntry(FitnessTrackingEntry entry)
    {
        using var con = new MySqlConnection(connStr);
        con.Open();
        string sql = "INSERT INTO Fitness_Tracking (User_ID, USER_NAME, JOINED_DATE, No_of_steps, Workout_Type, Calories_Burned) VALUES (@UserId, @UserName, @JoinedDate, @NoOfSteps, @WorkoutType, @CaloriesBurned)";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@UserId", entry.UserId);
        cmd.Parameters.AddWithValue("@UserName", entry.UserName);
        cmd.Parameters.AddWithValue("@JoinedDate", entry.JoinedDate.ToString("yyyy-MM-dd"));
        cmd.Parameters.AddWithValue("@NoOfSteps", entry.NoOfSteps);
        cmd.Parameters.AddWithValue("@WorkoutType", entry.WorkoutType);
        cmd.Parameters.AddWithValue("@CaloriesBurned", entry.CaloriesBurned);
        cmd.ExecuteNonQuery();
        Debug.WriteLine("Fitness Tracking Entry Added Successfully!");
    }

    public void DeleteById(int id)
    {
        using var con = new MySqlConnection(connStr);
        con.Open();
        string sql = "DELETE FROM Fitness_Tracking WHERE Tracking_ID = @TrackingId";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@TrackingId", id);
        int rowsAffected = cmd.ExecuteNonQuery();
        Debug.WriteLine(rowsAffected > 0 ? "Entry Deleted Successfully!" : "Entry Not Found.");
    }

    public void UpdateById(int id)
    {
        Debug.WriteLine("Update Process Started");
        Console.WriteLine();
        Console.WriteLine("Enter Tracking ID to Update:");
        int updateId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter User ID to Update:");
        int updateUserId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter User Name to Update:");
        string updateUserName = Console.ReadLine();
        Console.WriteLine("Enter Joined Date (YYYY-MM-DD) to Update:");
        DateTime updateJoinedDate = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Enter Number of Steps to Update:");
        int updateNoOfSteps = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Workout Type to Update:");
        string updateWorkoutType = Console.ReadLine();
        Console.WriteLine("Enter Calories Burned to Update:");
        double updateCaloriesBurned = Convert.ToDouble(Console.ReadLine());
        using var con = new MySqlConnection(connStr);
        con.Open();
        string sql = "UPDATE Fitness_Tracking SET User_ID = @UserId, USER_NAME = @UserName, JOINED_DATE = @JoinedDate, No_of_steps = @NoOfSteps, Workout_Type = @WorkoutType, Calories_Burned = @CaloriesBurned WHERE Tracking_ID = @TrackingId";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@UserId", updateUserId);
        cmd.Parameters.AddWithValue("@UserName", updateUserName);
        cmd.Parameters.AddWithValue("@JoinedDate", updateJoinedDate.ToString("yyyy-MM-dd"));
        cmd.Parameters.AddWithValue("@NoOfSteps", updateNoOfSteps);
        cmd.Parameters.AddWithValue("@WorkoutType", updateWorkoutType);
        cmd.Parameters.AddWithValue("@CaloriesBurned", updateCaloriesBurned);
        cmd.Parameters.AddWithValue("@TrackingId", updateId);
        int rowsAffected = cmd.ExecuteNonQuery();
        Debug.WriteLine(rowsAffected > 0 ? "Entry Updated Successfully!" : "Entry Not Found.");
    }

    public void SearchById(int id)
    {
        using var con = new MySqlConnection(connStr);
        con.Open();
        string sql = "SELECT * FROM Fitness_Tracking WHERE Tracking_ID = @TrackingId";
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@TrackingId", id);
        using var reader = cmd.ExecuteReader();
        Console.WriteLine();
        if (reader.Read())
        {
            Console.WriteLine($"Tracking ID: {reader["Tracking_ID"]}");
            Console.WriteLine($"User ID: {reader["User_ID"]}");
            Console.WriteLine($"User Name: {reader["USER_NAME"]}");
            Console.WriteLine($"Joined Date: {reader["JOINED_DATE"]}");
            Console.WriteLine($"Steps: {reader["No_of_steps"]}");
            Console.WriteLine($"Workout Type: {reader["Workout_Type"]}");
            Console.WriteLine($"Calories Burned: {reader["Calories_Burned"]}");
        }
        else
        {
            Debug.WriteLine("Entry Not Found.");
        }
    }

    public void DisplayAllData()
    {
        using var con = new MySqlConnection(connStr);
        con.Open();
        string sql = "SELECT * FROM Fitness_Tracking";
        using var cmd = new MySqlCommand(sql, con);
        using var reader = cmd.ExecuteReader();
        Console.WriteLine("\n===== Fitness Tracking Entries =====");
        Console.WriteLine();
        while (reader.Read())
        {
            Console.WriteLine($"Tracking ID: {reader["Tracking_ID"]}, User Name: {reader["USER_NAME"]}, Joined Date:{reader["JOINED_DATE"]}, Steps :{reader["No_of_steps"]} Workout: {reader["Workout_Type"]}, Calories Burned: {reader["Calories_Burned"]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IFitnessTrackingManagement fitnessTrackingManagement = new FitnessTrackingManagement();
        while (true)
        {
            
            Console.WriteLine("1. Add Fitness Entry");
            Console.WriteLine("2. Delete By ID");
            Console.WriteLine("3. Update By ID");
            Console.WriteLine("4. Search By ID");
            Console.WriteLine("5. Display All Data");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.WriteLine("Enter Your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    FitnessTrackingEntry entry = new FitnessTrackingEntry();
                    Console.WriteLine("Enter User ID");
                    entry.UserId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter User Name");
                    entry.UserName = Console.ReadLine();
                    Console.WriteLine("Enter Joined Date (YYYY-MM-DD)");
                    entry.JoinedDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter Number of Steps");
                    entry.NoOfSteps = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Workout Type");
                    entry.WorkoutType = Console.ReadLine();
                    Console.WriteLine("Enter Calories Burned");
                    entry.CaloriesBurned = Convert.ToDouble(Console.ReadLine());
                    fitnessTrackingManagement.AddEntry(entry);
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    fitnessTrackingManagement.DeleteById(id);
                    break;
                case 3:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    fitnessTrackingManagement.UpdateById(id);
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    fitnessTrackingManagement.SearchById(id);
                    break;
                case 5:
                    fitnessTrackingManagement.DisplayAllData();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Debug.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}

