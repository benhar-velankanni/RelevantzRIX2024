using CustomerService.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
    }
}
