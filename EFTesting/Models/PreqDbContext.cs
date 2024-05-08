using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFTesting.Models;

public partial class PreqDbContext : DbContext
{
    public PreqDbContext()
    {
    }

    public PreqDbContext(DbContextOptions<PreqDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PreQual> PreQuals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TCWLPF2GD13M;Database=PreqDB;TrustServerCertificate=True;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PreQual>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK_Preq");

            entity.ToTable("PreQual");

            entity.Property(e => e.CatId).HasMaxLength(50);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.ModifiedTime).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
