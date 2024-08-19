using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace task_19_8.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QJHUPSA;Database=task;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__category__213EE7743ECFEE85");

            entity.ToTable("category");

            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.CImage)
                .IsUnicode(false)
                .HasColumnName("c_image");
            entity.Property(e => e.CName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("c_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__products__82E06B91D81A6085");

            entity.ToTable("products");

            entity.Property(e => e.PId).HasColumnName("p_id");
            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.PDes)
                .IsUnicode(false)
                .HasColumnName("p_des");
            entity.Property(e => e.PImage)
                .IsUnicode(false)
                .HasColumnName("p_image");
            entity.Property(e => e.PName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("p_name");
            entity.Property(e => e.PPric)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("p_pric");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK__products__c_id__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
