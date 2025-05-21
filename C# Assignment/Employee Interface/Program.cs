
using System;
using MySql.Data.MySqlClient;

public interface IEmployee {
    void AddEmployee(Employee employee);
    void SearchEmployee(int id);
    void UpdateEmployee(int id, Employee updatedEmployee);
    void DeleteEmployee(int id);
    void DisplayAll();
}

public class Employee {
    public string Name;
    public int Age;
    public string Gender;
    public string Designation;

    public Employee(string name, int age, string gender, string designation) {
        Name = name;
        Age = age;
        Gender = gender;
        Designation = designation;
    }
}

public class EmployeeService : IEmployee {
    static string connStr = "server=localhost;user=root;password=begonia@2003;database=EmpInterface; port=3306; SslMode=none;";

    public void AddEmployee(Employee employee) {
        using var connection = new MySqlConnection(connStr);
        connection.Open();
        string sql = "INSERT INTO Emp (Name, Age, Gender, Designation) VALUES (@Name, @Age, @Gender, @Designation)";
        using var command = new MySqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Name", employee.Name);
        command.Parameters.AddWithValue("@Age", employee.Age);
        command.Parameters.AddWithValue("@Gender", employee.Gender);
        command.Parameters.AddWithValue("@Designation", employee.Designation);
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void SearchEmployee(int id) {
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        string sql = "SELECT * FROM Emp WHERE EmployeeID = @ID";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@ID", id);
        using MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            Console.WriteLine("ID: " + reader["EmployeeID"]);
            Console.WriteLine("Name: " + reader["Name"]);
            Console.WriteLine("Age: " + reader["Age"]);
            Console.WriteLine("Gender: " + reader["Gender"]);
            Console.WriteLine("Designation: " + reader["Designation"]);
        }
        conn.Close();
    }

    public void UpdateEmployee(int id, Employee updatedEmployee) {
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        string sql = "UPDATE Emp SET Name = @Name, Age = @Age, Gender = @Gender, Designation = @Designation WHERE EmployeeID = @ID";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Name", updatedEmployee.Name);
        cmd.Parameters.AddWithValue("@Age", updatedEmployee.Age);
        cmd.Parameters.AddWithValue("@Gender", updatedEmployee.Gender);
        cmd.Parameters.AddWithValue("@Designation", updatedEmployee.Designation);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void DeleteEmployee(int id) {
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        string sql = "DELETE FROM Emp WHERE EmployeeID = @ID";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@ID", id);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void DisplayAll() {
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        string sql = "SELECT * FROM Emp";
        using var cmd = new MySqlCommand(sql, conn);
        using MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) {
            Console.WriteLine("ID: " + reader["EmployeeID"]);
            Console.WriteLine("Name: " + reader["Name"]);
            Console.WriteLine("Age: " + reader["Age"]);
            Console.WriteLine("Gender: " + reader["Gender"]);
            Console.WriteLine("Designation: " + reader["Designation"]);
        }
        conn.Close();
    }
}

class Program {
    static void Main() {
        IEmployee service = new EmployeeService(); 
        while (true) {
            Console.WriteLine("\n1. Add Employee");
            Console.WriteLine("2. Search Employee");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Display All Employees");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) {
                case 1:
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Gender: ");
                    string gender = Console.ReadLine();
                    Console.Write("Enter Designation: ");
                    string designation = Console.ReadLine();
                    Employee newEmp = new Employee(name, age, gender, designation);
                    service.AddEmployee(newEmp);
                    break;

                case 2:
                    Console.Write("Enter ID to search: ");
                    int searchId = Convert.ToInt32(Console.ReadLine());
                    service.SearchEmployee(searchId);
                    break;

                case 3:
                    Console.Write("Enter ID to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter New Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter New Age: ");
                    int newAge = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter New Gender: ");
                    string newGender = Console.ReadLine();
                    Console.Write("Enter New Designation: ");
                    string newDesignation = Console.ReadLine();
                    Employee updatedEmp = new Employee(newName, newAge, newGender, newDesignation);
                    service.UpdateEmployee(updateId, updatedEmp);
                    break;

                case 4:
                    Console.Write("Enter ID to delete: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    service.DeleteEmployee(deleteId);
                    break;

                case 5:
                    service.DisplayAll();
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
