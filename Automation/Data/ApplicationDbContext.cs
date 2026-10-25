using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Automation.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerTbl> CustomerTbls { get; set; }

    public virtual DbSet<StockTable> StockTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerTbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CUSTOMER__3214EC27EDB99F99");

            entity.ToTable("CUSTOMER_TBL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CUST_NAME");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MOBILE");
        });

        modelBuilder.Entity<StockTable>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__STOCK_TA__AA1D43782A226C29");

            entity.ToTable("STOCK_TABLE");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODE");
            entity.Property(e => e.BatchNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BATCH_NO");
            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CATEGORY");
            entity.Property(e => e.ExpDt).HasColumnName("EXP_DT");
            entity.Property(e => e.MfgDt).HasColumnName("MFG_DT");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(6, 2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.Units)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("UNITS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
