//AppDbContext.cs

using Microsoft.EntityFrameworkCore;
using GlossaryManagementService.Model;

namespace GlossaryManagementService.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<GlossaryManagement> GlossaryManagements { get; set; }
    }
}
