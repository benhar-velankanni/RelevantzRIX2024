using Microsoft.EntityFrameworkCore;
using SkillTransferApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Session> Sessions { get; set; }
    public DbSet<Skill> Skills { get; set; }
}
