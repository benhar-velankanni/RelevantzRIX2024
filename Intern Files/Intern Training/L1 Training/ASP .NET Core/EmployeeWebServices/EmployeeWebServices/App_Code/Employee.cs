using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebServices.App_Code
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
    }
}