using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DA_TOTNGHIEP.Models
{
    public partial class db_DOANTOTNGHIEPContext : DbContext
    {
        public db_DOANTOTNGHIEPContext()
        {
        }

        public db_DOANTOTNGHIEPContext(DbContextOptions<db_DOANTOTNGHIEPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<ImageProduct> ImageProduct { get; set; }
        public virtual DbSet<ImportWarehouse> ImportWarehouse { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<WarehouseDetails> WarehouseDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=QUOCTH4NG\\SQLEXPRESS;Initial Catalog=db_DOANTOTNGHIEP;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<Carts>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifyAt)
                    .HasColumnName("Modify_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Accounts");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Products");
            });

            modelBuilder.Entity<ImageProduct>(entity =>
            {
                entity.Property(e => e.ImageName).IsRequired();

                entity.Property(e => e.ProductsID).HasColumnName("ProductsID");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.ImageProduct)
                    .HasForeignKey(d => d.ProductsID)
                    .HasConstraintName("FK_ImageProduct_Products");
            });

            modelBuilder.Entity<ImportWarehouse>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).IsRequired();

                entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");

                entity.Property(e => e.Supplier).IsRequired();

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ImportWarehouse)
                    .HasForeignKey(d => d.ShipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImportWarehouse_WarehouseDetails");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.ImportWarehouse)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImportWarehouse_Warehouse");
            });

            modelBuilder.Entity<InvoiceDetails>(entity =>
            {
                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.ProductItems)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ProductItemsId);
            });

            modelBuilder.Entity<ProductTypes>(entity =>
            {
                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.ImageName).IsRequired();

                entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");

                entity.Property(e => e.Sku).HasColumnName("SKU");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("FK_Products_WarehouseDetails");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_Products_Warehouse");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImportWarehouseId).HasColumnName("Import_WarehouseID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.WarehouseDetailsId).HasColumnName("WarehouseDetailsID");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.HasOne(d => d.WarehouseDetails)
                    .WithMany(p => p.Warehouse)
                    .HasForeignKey(d => d.WarehouseDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_WarehouseDetails");
            });

            modelBuilder.Entity<WarehouseDetails>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Shipment)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
