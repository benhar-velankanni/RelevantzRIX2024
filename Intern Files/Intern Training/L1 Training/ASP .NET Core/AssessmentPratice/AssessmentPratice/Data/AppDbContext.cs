using System;
using System.Collections.Generic;
using AssessmentPratice.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace AssessmentPratice.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enroll> Enrolls { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;user=root;password=root;database=CoursesDb;port=3306", ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PRIMARY");

            entity.ToTable("courses");

            entity.Property(e => e.CourseName).HasMaxLength(100);
        });

        modelBuilder.Entity<Enroll>(entity =>
        {
            entity.HasKey(e => e.EnrollId).HasName("PRIMARY");

            entity.ToTable("enroll");

            entity.HasIndex(e => e.CourseId, "CourseId").IsUnique();

            entity.HasIndex(e => e.StudentId, "StudentId").IsUnique();

            entity.HasOne(d => d.Course).WithOne(p => p.Enroll)
                .HasForeignKey<Enroll>(d => d.CourseId)
                .HasConstraintName("enroll_ibfk_2");

            entity.HasOne(d => d.Student).WithOne(p => p.Enroll)
                .HasForeignKey<Enroll>(d => d.StudentId)
                .HasConstraintName("enroll_ibfk_1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PRIMARY");

            entity.ToTable("students");

            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
