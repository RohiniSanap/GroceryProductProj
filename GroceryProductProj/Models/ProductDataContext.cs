using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GroceryProductProj.Models
{
    public partial class ProductDataContext : DbContext
    {
        public ProductDataContext()
        {
        }

        public ProductDataContext(DbContextOptions<ProductDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GroceryProduct> GroceryProducts { get; set; } = null!;
        public virtual DbSet<LoginPage> LoginPages { get; set; } = null!;
        public virtual DbSet<SalePage> SalePages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=WJLP-1481; Initial Catalog=ProductData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__GroceryP__9834FB9A11F2B081");

                entity.ToTable("GroceryProduct");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_ID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");

                entity.Property(e => e.ProductQuantity).HasColumnName("Product_Quantity");
            });

            modelBuilder.Entity<LoginPage>(entity =>
            {
                entity.ToTable("LoginPage");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Pasword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalePage>(entity =>
            {
                entity.ToTable("SalePage");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Name");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
