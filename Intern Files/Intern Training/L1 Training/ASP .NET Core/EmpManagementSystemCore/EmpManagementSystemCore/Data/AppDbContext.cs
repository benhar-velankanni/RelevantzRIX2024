using EmpManagementSystemCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmpManagementSystemCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
