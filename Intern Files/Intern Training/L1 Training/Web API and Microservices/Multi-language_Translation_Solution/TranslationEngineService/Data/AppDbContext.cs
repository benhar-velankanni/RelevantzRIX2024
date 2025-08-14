//AppDbContext.cs

using Microsoft.EntityFrameworkCore;
using TranslationEngineService.Model;

namespace TranslationEngineService.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TranslationEngine> TranslationEngines{ get; set; }
    }
}
