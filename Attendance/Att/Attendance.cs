using System;
using MySql.Data.MySqlClient;
public class Attendance
{

    public static string connStr = "server=localhost;user=root;password= Admin@123;database=Attendance; port=3306";
    ICollection<Student> students = new List<Student>();
    public void AddStudent(Student student)
    {

        using var conn = new MySqlConnection(connStr);
        conn.Open();
        using var cmd = new MySqlCommand("insert into student(id,name,status) values(@id,@name,@status)", conn);
        cmd.Parameters.AddWithValue("@id", student.Id);
        cmd.Parameters.AddWithValue("@name", student.Name);
        cmd.Parameters.AddWithValue("@status", student.Present);

        cmd.ExecuteNonQuery();
        conn.Close();
        students.Add(student);
        Console.WriteLine("Added Successfully");


    }

    public void checkStatus(int id)
    {

        var student = students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            if (!student.Present)
            {
                Console.WriteLine("Student is Absent");
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                using var cmd = new MySqlCommand("DELETE FROM student WHERE id = @id AND status = 0", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                Console.WriteLine("Student is Present");
            }
        }
        else
        {
            Console.WriteLine("Student not found in memory.");
        }
    }


    //attendance.updateStatus(2, "Absent");
    public void updateAttendance(int id, string status)
    {
        if (status == "Present")
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            using var cmd = new MySqlCommand("UPDATE student SET status = 1 WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        else if (status == "Absent")
        {
            using var conn = new MySqlConnection(connStr);
            conn.Open();
            using var cmd = new MySqlCommand("UPDATE student SET status = 0 WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
    }

    


    



    



    
}