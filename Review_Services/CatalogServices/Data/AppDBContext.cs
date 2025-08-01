using Services.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Services.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Review> Reviews { get; set; }

    }
}
