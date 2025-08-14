using Microsoft.EntityFrameworkCore;
using CatalogServices.Model;

namespace CatalogServices.Data
{

    public class AppDbContext : DbContext

    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Catalog> Catalogs { get; set; }

    }

}