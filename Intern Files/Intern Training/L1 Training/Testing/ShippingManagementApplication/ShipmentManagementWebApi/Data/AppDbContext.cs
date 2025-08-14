using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ShipmentManagementWebApi.Models;

namespace ShipmentManagementWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

    }
}
