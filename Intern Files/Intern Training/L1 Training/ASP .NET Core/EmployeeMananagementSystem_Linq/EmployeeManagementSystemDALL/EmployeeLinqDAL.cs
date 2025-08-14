using EmployeeManagementSystemMD;
using System.Linq;
using System.Collections.Generic;
using EmployeeManagementSystemMD.Models;
using EmployeeManagementSystemDALL.AppData;

namespace EmployeeManagementSystemDALL
{
    public class EmployeeLinqDAL
    {
        public List<Employee> GetEmployees() 
        {
            using (var db = new MyDBContext())
            {
                return db.Employees.ToList();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (var db = new MyDBContext())
            { 
                return db.Employees.FirstOrDefault(e => e.EmployeeId == id);
            }
        }

        public void InsertEmployee(Employee employee)
        {
            using (var db = new MyDBContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var db = new MyDBContext())
            {
                var existing = db.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
                if (existing != null)
                {
                    existing.EmployeeName = employee.EmployeeName;
                    existing.Department = employee.Department;
                    existing.Email = employee.Email;
                    existing.HireDate = employee.HireDate;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var db = new MyDBContext())
            {
                var employee = db.Employees.FirstOrDefault(e => e.EmployeeId == id);
                if (employee != null)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                }
            }
        }
    }
}
