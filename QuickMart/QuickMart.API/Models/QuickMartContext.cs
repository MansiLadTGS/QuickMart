using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuickMart.API.Models;

public partial class QuickMartContext : DbContext
{
    public QuickMartContext()
    {
    }

    public QuickMartContext(DbContextOptions<QuickMartContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartDetail> CartDetails { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<CustomerPaymentProfile> CustomerPaymentProfiles { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderMaster> OrderMasters { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductMaster> ProductMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=QuickMart;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartDetail>(entity =>
        {
            entity.HasKey(e => e.CartId);

            entity.ToTable("CartDetail");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.CartDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CartDetail_Customer");

            entity.HasOne(d => d.Product).WithMany(p => p.CartDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_CartDetail_ProductMaster");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasColumnType("numeric(18, 0)");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.ToTable("CustomerAddress");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerAddress_Customer");
        });

        modelBuilder.Entity<CustomerPaymentProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId);

            entity.ToTable("CustomerPaymentProfile");

            entity.Property(e => e.ProfileId).HasColumnName("ProfileID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.PgatewayCustomerId)
                .HasMaxLength(100)
                .HasColumnName("PGatewayCustomerID");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerPaymentProfiles)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerPaymentProfile_Customer");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.OrderAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderItems_ProductMaster");
        });

        modelBuilder.Entity<OrderMaster>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("OrderMaster");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CreatedOn).HasMaxLength(100);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveredDate).HasColumnType("datetime");
            entity.Property(e => e.DiscountValue).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ModifiedOn).HasMaxLength(100);
            entity.Property(e => e.NetValue).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatus).HasMaxLength(20);
            entity.Property(e => e.PaymentMode).HasMaxLength(20);
            entity.Property(e => e.PaymentProfileId).HasColumnName("PaymentProfileID");
            entity.Property(e => e.PgatewayTxnId)
                .HasMaxLength(100)
                .HasColumnName("PGatewayTxnID");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Address).WithMany(p => p.OrderMasters)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_OrderMaster_CustomerAddress");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderMasters)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_OrderMaster_OrderMaster");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ProductMaster>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("ProductMaster");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedBy).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.MediaType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Moq)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("MOQ");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductMasters)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_ProductMaster_ProductCategory");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
