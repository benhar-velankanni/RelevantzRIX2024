using EmployeeManagementSystemDALL;
using EmployeeManagementSystemMD;
using EmployeeManagementSystemMD.Models;
using System.Collections.Generic;

namespace EmployeeManagementSystemBAL
{
    public class EmployeeLinqBAL
    {
        private readonly EmployeeLinqDAL _empLinqDal;

        public EmployeeLinqBAL()
        {
            _empLinqDal = new EmployeeLinqDAL();
        }

        public void AddEmployee(Employee employee)
        {
            _empLinqDal.InsertEmployee(employee);
        }

        public void ModifyEmployee(Employee employee)
        {
            _empLinqDal.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id) { 
            _empLinqDal.DeleteEmployee(id);
        }

        public Employee GetEmployeeById(int id)
        {
            return _empLinqDal.GetEmployeeById(id);
        }

        public List<Employee> GetEmployeeList() { 
            return _empLinqDal.GetEmployees();
        }
    }
}
