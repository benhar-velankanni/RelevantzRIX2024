//AppDbContext.cs

using Microsoft.EntityFrameworkCore;
using LanguageDetectionService.Model;

namespace LanguageDetectionService.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LanguageDetection> LanguageDetections { get; set; }
    }
}
