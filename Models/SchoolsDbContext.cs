using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServiceBasedApplication.Models;

public partial class SchoolsDbContext : DbContext
{
    public SchoolsDbContext()
    {
    }

    public SchoolsDbContext(DbContextOptions<SchoolsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }
    
    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Enrollment");

            entity.ToTable("Enrollment");

            entity.HasIndex(e => e.CourseId, "IX_CourseID");

            entity.HasIndex(e => e.StudentId, "IX_StudentID");

            entity.HasOne(d => d.Course)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_dbo.Enrollment_dbo.Course_CourseID");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_dbo.Enrollment_dbo.Student_StudentID");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Student");

            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
