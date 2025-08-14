using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using static EmployeeWebServices.EmployeeService;

namespace EmployeeWebServices
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        [WebMethod]
        public List<Employees> GetAllEmployees()
        {
            List<Employees> employees = new List<Employees>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Employees", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employees
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

        public class Employees
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public string Department { get; set; }
            public string Email { get; set; }
            public DateTime HireDate { get; set; }
        }
    }
}
