using System;
using MySql.Data.MySqlClient;

class Employee{
    static string connStr = "server=localhost;user=root;password=begonia@2003;database=Employees;port=3306;SslMode=none";

    public static void AddEmployee(){
        Console.WriteLine("-----Add Employee-----");
        Console.WriteLine("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Employee Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Employee Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Employee Designation:");
        string designation = Console.ReadLine();
        Console.WriteLine("Enter Employee Salary: ");
        double salary = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Employee Address: ");
        string address = Console.ReadLine();
        Console.WriteLine("Enter Employee Gender:");
        string gender = Console.ReadLine();
        Console.WriteLine("Enter Employee Contact Number: ");
        string contact = Console.ReadLine();

        using var conn = new MySqlConnection(connStr);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO Employees (EmployeeID,EmployeeName,Age,Designation,Salary,Address,Gender,ContactNumber) VALUES (@id,@name,@age,@designation,@salary,@address,@gender,@contact)";
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@age", age);
        cmd.Parameters.AddWithValue("@designation", designation);
        cmd.Parameters.AddWithValue("@salary", salary);
        cmd.Parameters.AddWithValue("@address", address);
        cmd.Parameters.AddWithValue("@gender", gender);
        cmd.Parameters.AddWithValue("@contact", contact);
        cmd.ExecuteNonQuery();
        conn.Close();
        Console.WriteLine("Employee Added Successfully");
        Console.WriteLine("----------------------------");

    }

    public static void SearchEmployee(){
        Console.WriteLine("Enter Employee ID to search: ");
        int id = int.Parse(Console.ReadLine());
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Employees WHERE EmployeeID = @id";
        cmd.Parameters.AddWithValue("@id", id);
        var reader = cmd.ExecuteReader();
        if(reader.Read()){
            Console.WriteLine("-----Employee Found-----");
            Console.WriteLine("Employee ID: " + reader["EmployeeID"]);
            Console.WriteLine("Employee Name: " + reader["EmployeeName"]);
            Console.WriteLine("Employee Age: " + reader["Age"]);
            Console.WriteLine("Employee Designation: " + reader["Designation"]);
            Console.WriteLine("Employee Salary: " + reader["Salary"]);
            Console.WriteLine("Employee Address: " + reader["Address"]);
            Console.WriteLine("Employee Gender: " + reader["Gender"]);
            Console.WriteLine("Employee Contact Number: " + reader["ContactNumber"]);
            Console.WriteLine("----------------------------");
        }
        else{
            Console.WriteLine("-----Employee Not Found-----");
            Console.WriteLine("----------------------------");
        }
        conn.Close();
    }

    public static void UpdateEmployee(){
        Console.WriteLine("Enter Employee ID to update: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Employee's New Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Employee's New Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Employee's New Designation: ");
        string designation = Console.ReadLine();
        Console.WriteLine("Enter Employee's New Salary: ");
        double salary = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Employee's New Address: ");
        string address = Console.ReadLine();
        Console.WriteLine("Enter Employee's New Gender: ");
        string gender = Console.ReadLine();
        Console.WriteLine("Enter Employee's New Contact Number: ");
        string contact = Console.ReadLine();

        using var conn = new MySqlConnection(connStr);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "UPDATE Employees SET EmployeeName = @name, Age = @age, Designation = @designation, Salary = @salary, Address = @address, Gender = @gender, ContactNumber = @contact WHERE EmployeeID = @id";
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@age", age);
        cmd.Parameters.AddWithValue("@designation", designation);
        cmd.Parameters.AddWithValue("@salary", salary);
        cmd.Parameters.AddWithValue("@address", address);
        cmd.Parameters.AddWithValue("@gender", gender);
        cmd.Parameters.AddWithValue("@contact", contact);
        cmd.ExecuteNonQuery();
        conn.Close();
        Console.WriteLine("Employee Updated Successfully");
        Console.WriteLine("----------------------------");

    } 

    public static void DeleteEmployee(){
        Console.WriteLine("Enter Employee ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        using var conn = new MySqlConnection(connStr);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "DELETE FROM Employees WHERE EmployeeID = @id";
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public static void ViewEmployee(){
        Console.WriteLine("-----All Employees-----");
        using var conn = new MySqlConnection(connStr);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Employees";
        var reader = cmd.ExecuteReader();
        while(reader.Read()){
            Console.WriteLine("-----Employee Found-----");
            Console.WriteLine("Employee ID: " + reader["EmployeeID"]);
            Console.WriteLine("Employee Name: " + reader["EmployeeName"]);
            Console.WriteLine("Employee Age: " + reader["Age"]);
            Console.WriteLine("Employee Designation: " + reader["Designation"]);
            Console.WriteLine("Employee Salary: " + reader["Salary"]);
            Console.WriteLine("Employee Address: " + reader["Address"]);
            Console.WriteLine("Employee Gender: " + reader["Gender"]);
            Console.WriteLine("Employee Contact Number: " + reader["ContactNumber"]);
            Console.WriteLine("----------------------------");
        }
        conn.Close();
    }  


}

class Program{
    static void Main(){
        while(true){
            Console.WriteLine("-----Employee Management System-----");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Search Employee");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. View All Employees");
            Console.WriteLine("6. Exit");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Enter your choice: ");
            
            int choice = int.Parse(Console.ReadLine());
            switch(choice){
                case 1:
                    Employee.AddEmployee();
                    break;
                case 2:
                    Employee.SearchEmployee();
                    break;
                case 3:
                    Employee.UpdateEmployee();
                    break;
                case 4:
                    Employee.DeleteEmployee();
                    break;
                case 5:
                    Employee.ViewEmployee();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}