using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Krasotka2.Entities;

namespace Krasotka2.Entities.Persistence
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryType> CategoryTypes { get; set; } = null!;
        public virtual DbSet<ManufactureType> ManufactureTypes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderPropuct> OrderPropucts { get; set; } = null!;
        public virtual DbSet<PointType> PointTypes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<StatusType> StatusTypes { get; set; } = null!;
        public virtual DbSet<SupplierType> SupplierTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public List<Product>? Propucts { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-72CK5C8; Database= KRASOTKA2; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryType>(entity =>
            {
                entity.ToTable("CategoryType");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ManufactureType>(entity =>
            {
                entity.ToTable("ManufactureType");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .HasColumnName("CVV")
                    .IsFixedLength();

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDateDelivery).HasColumnType("datetime");

                entity.HasOne(d => d.PickupPointNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PickupPoint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__PickupPoi__2D27B809");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__Status__2E1BDC42");
            });

            modelBuilder.Entity<OrderPropuct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ArticleNumber })
                    .HasName("PK__OrderPro__E059CABBB3468932");

                entity.ToTable("OrderPropuct");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ArticleNumber).HasMaxLength(100);

                entity.HasOne(d => d.ArticleNumberNavigation)
                    .WithMany(p => p.OrderPropucts)
                    .HasForeignKey(d => d.ArticleNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProp__Artic__3C69FB99");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPropucts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProp__Order__3B75D760");
            });

            modelBuilder.Entity<PointType>(entity =>
            {
                entity.ToTable("PointType");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Article)
                    .HasName("PK__Product__4943444B9FD1A0FA");

                entity.ToTable("Product");

                entity.Property(e => e.Article).HasMaxLength(100);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__Product__Categor__38996AB5");

                entity.HasOne(d => d.ManufactureNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Manufacture)
                    .HasConstraintName("FK__Product__Manufac__36B12243");

                entity.HasOne(d => d.SupplierNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Supplier)
                    .HasConstraintName("FK__Product__Supplie__37A5467C");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.ToTable("StatusType");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<SupplierType>(entity =>
            {
                entity.ToTable("SupplierType");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__Role__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
