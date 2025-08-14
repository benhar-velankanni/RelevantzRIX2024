using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TeaTokenManagement.Models;

namespace TeaTokenManagement.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TeaTokenLog> TeaTokenLogs { get; set; }
    }
}
