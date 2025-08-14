using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using EmployeeManagementSystemMD.Models;

namespace EmployeeManagementSystemMD.DAL
{
    public class EmployeeDal
    {
        string connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Employees", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        EmployeeName = reader["EmployeeName"].ToString(),
                        Department = reader["Department"].ToString(),
                        Email = reader["Email"].ToString(),
                        HireDate = Convert.ToDateTime(reader["HireDate"])
                    });
                }
            }
            return employees;
        }

        public void InsertEmployee(Employee emp)
        {
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                conn.Open();
                string query = "INSERT INTO Employees (EmployeeName, Department, Email, HireDate) VALUES (@Name, @Dept, @Email, @HireDate)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Dept", emp.Department);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@HireDate", emp.HireDate);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                conn.Open();
                string query = "UPDATE Employees SET EmployeeName=@Name, Department=@Dept, Email=@Email, HireDate=@HireDate WHERE EmployeeId=@Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Dept", emp.Department);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@HireDate", emp.HireDate);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                conn.Open();
                string query = "DELETE FROM Employees WHERE EmployeeId=@Id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
