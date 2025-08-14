using System.Collections.Generic;
using EmployeeManagementSystemMD.Models;
using EmployeeManagementSystemMD.DAL;

namespace EmployeeManagementSystemMD.BAL
{
    public class EmployeeBAL
    {
        EmployeeDal employeeDAL = new EmployeeDal();

        public List<Employee> GetAllEmployees() => employeeDAL.GetAllEmployees();
        public void InsertEmployee(Employee emp) => employeeDAL.InsertEmployee(emp);
        public void UpdateEmployee(Employee emp) => employeeDAL.UpdateEmployee(emp);
        public void DeleteEmployee(int id) => employeeDAL.DeleteEmployee(id);
    }
}
