using Microsoft.EntityFrameworkCore;
using ExpenseTrackerWebApi.Models;

namespace ExpenseTrackerWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
