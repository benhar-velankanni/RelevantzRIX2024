using Microsoft.EntityFrameworkCore;
using BeverageTokenApi.Models;

namespace BeverageTokenApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<TokenRequest> TokenRequests => Set<TokenRequest>();
    public DbSet<WorkingDay> WorkingDays => Set<WorkingDay>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<TokenRequest>()
            .HasOne(tr => tr.User)
            .WithMany()
            .HasForeignKey(tr => tr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WorkingDay>()
            .HasIndex(w => w.Date)
            .IsUnique();
    }
}
