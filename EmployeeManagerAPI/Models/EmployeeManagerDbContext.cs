using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerAPI.Models;

public partial class EmployeeManagerDbContext : DbContext
{
    public EmployeeManagerDbContext()
    {
    }

    public EmployeeManagerDbContext(DbContextOptions<EmployeeManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:vstestserver.database.windows.net,1433;Initial Catalog=EmployeeDBForIP;Persist Security Info=False;User ID=VSAzureSqlLogin;Password=VSAzure@2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC074BBCE04B");

            entity.ToTable("Employee");

            entity.Property(e => e.Certification).HasMaxLength(250);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Department)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.EngagedForClient)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.IsBillable)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Manager)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.OnBench)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.OnPip)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("OnPIP");
            entity.Property(e => e.ProjectName).HasMaxLength(250);
            entity.Property(e => e.SkillSet).HasMaxLength(250);
            entity.Property(e => e.SubDepartment)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
