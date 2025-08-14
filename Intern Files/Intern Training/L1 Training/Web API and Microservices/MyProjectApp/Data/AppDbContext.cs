using Microsoft.EntityFrameworkCore;
using MyProductWebAPI.Model;
using System;
using System.Collections.Generic;

namespace MyProductWebAPI.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
    }
}
