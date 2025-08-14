using Microsoft.EntityFrameworkCore;
using NameService.Model;

namespace NameService.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Name> Names { get; set; }
    }
}

