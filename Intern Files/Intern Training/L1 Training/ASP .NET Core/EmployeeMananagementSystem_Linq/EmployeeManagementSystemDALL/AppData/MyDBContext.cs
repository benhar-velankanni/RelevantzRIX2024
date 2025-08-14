using EmployeeManagementSystemMD.Models;
using System.Data.Entity;

namespace EmployeeManagementSystemDALL.AppData
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("DefaultConnection") { }

        public DbSet<Employee> Employees { get; set; }
    }
}
