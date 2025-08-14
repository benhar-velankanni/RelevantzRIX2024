//AppDbContext.cs

using Microsoft.EntityFrameworkCore;
using TeacherAPI.Model;

namespace TeacherAPI.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Teacher> Teachers { get; set; }
    }
}