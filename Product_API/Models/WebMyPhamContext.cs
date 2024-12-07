using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Product_API.Models;

public partial class WebMyPhamContext : DbContext
{
    public WebMyPhamContext()
    {
    }

    public WebMyPhamContext(DbContextOptions<WebMyPhamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblProduct> TblProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("tblProducts");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.Images).IsUnicode(false);
            entity.Property(e => e.ProductName).HasMaxLength(250);
            entity.Property(e => e.Sku)
                .IsUnicode(false)
                .HasColumnName("SKU");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
