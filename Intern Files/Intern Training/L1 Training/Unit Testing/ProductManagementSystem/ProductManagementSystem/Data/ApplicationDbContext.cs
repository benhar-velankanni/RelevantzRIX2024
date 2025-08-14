using Microsoft.EntityFrameworkCore;
using ProductmangementSystem.Models;
using System.Collections.Generic;

namespace ProductmangementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
