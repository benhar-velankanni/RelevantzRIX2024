using Microsoft.EntityFrameworkCore;
using TimeEntries.Entity;

namespace TimeEntries.Data
{
    /// <summary>
    /// Represents the application's database context for Entity Framework Core.
    /// Manages entity sets and database interactions.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructor that accepts DbContext options and passes them to the base class.
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// DbSet representing the collection of TimeEntry entities in the database.
        /// </summary>
        public DbSet<TimeEntry> TimeEntries { get; set; }
    }
}
