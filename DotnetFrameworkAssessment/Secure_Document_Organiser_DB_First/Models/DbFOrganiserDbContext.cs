using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Secure_Document_Organiser_DB_First.Models;

public partial class DbFOrganiserDbContext : DbContext
{
    public DbFOrganiserDbContext()
    {
    }

    public DbFOrganiserDbContext(DbContextOptions<DbFOrganiserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Folder> Folders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=DB_F_OrganiserDb;user id=root;password=123;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.FolderId, "FolderId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EncryptedContent).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Folder).WithMany(p => p.Documents)
                .HasForeignKey(d => d.FolderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Documents_ibfk_1");
        });

        modelBuilder.Entity<Folder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Folders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Folders_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
