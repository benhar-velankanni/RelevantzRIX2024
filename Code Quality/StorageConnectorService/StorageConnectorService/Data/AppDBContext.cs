using Microsoft.EntityFrameworkCore;
using StorageConnectorService.Model;
namespace StorageConnectorService.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<StorageConnector> StorageConnectors { get; set; }
    }
}
