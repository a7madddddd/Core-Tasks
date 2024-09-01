using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Asp_Core_Api_Project.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Info> Infos { get; set; }

    public virtual DbSet<MoreProduct> MoreProducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QJHUPSA;Database=task;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Carts__51BCD797AA24113F");

            entity.HasIndex(e => e.UsId, "UQ__Carts__2E701A66BF6CDCBF").IsUnique();

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.UsId).HasColumnName("us_id");

            entity.HasOne(d => d.Us).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.UsId)
                .HasConstraintName("FK_UserCart");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CartItem__488B0B2A8C82C510");

            entity.HasIndex(e => new { e.CartId, e.PId }, "UQ__CartItem__5992D12F98059084").IsUnique();

            entity.Property(e => e.CartItemId).HasColumnName("CartItemID");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.PId).HasColumnName("p_id");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK_Cart");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.PId)
                .HasConstraintName("FK_Product");
        });

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

        modelBuilder.Entity<Info>(entity =>
        {
            entity.HasKey(e => e.InId).HasName("PK__info__1CD08BE9BDE0F414");

            entity.ToTable("info");

            entity.Property(e => e.InId).HasColumnName("in_id");
            entity.Property(e => e.InDes)
                .IsUnicode(false)
                .HasColumnName("in_des");
            entity.Property(e => e.InName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("in_name");
        });

        modelBuilder.Entity<MoreProduct>(entity =>
        {
            entity.HasKey(e => e.MpId).HasName("PK__moreProd__72C1AF32A58FCA92");

            entity.ToTable("moreProducts");

            entity.Property(e => e.MpId).HasColumnName("mp_id");
            entity.Property(e => e.MpDes)
                .IsUnicode(false)
                .HasColumnName("mp_des");
            entity.Property(e => e.MpImage)
                .IsUnicode(false)
                .HasColumnName("mp_image");
            entity.Property(e => e.MpName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mp_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrId).HasName("PK__orders__3F90F410903D5BD7");

            entity.ToTable("orders");

            entity.Property(e => e.OrId).HasColumnName("or_id");
            entity.Property(e => e.OrDate).HasColumnName("or_date");
            entity.Property(e => e.UsId).HasColumnName("us_id");

            entity.HasOne(d => d.Us).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UsId)
                .HasConstraintName("FK__orders__us_id__4BAC3F29");
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

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsId).HasName("PK__users__2E701A67F447DD1C");

            entity.ToTable("users");

            entity.Property(e => e.UsId).HasColumnName("us_id");
            entity.Property(e => e.UsEm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("us_em");
            entity.Property(e => e.UsName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("us_name");
            entity.Property(e => e.UsPas)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("us_pas");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.Role });

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UsId).HasColumnName("us_id");

            entity.HasOne(d => d.Us).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UsId)
                .HasConstraintName("FK_UserRole_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
