using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Name).IsRequired();
        builder.Property(p => p.Price)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        // Product relationships
        // modelBuilder.Entity<Product>()
            
            // .HasOne(p => p.Category)
            // .WithMany()
            // .HasForeignKey(p => p.CategoryId);

                builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);
            
            // modelBuilder.Entity<Product>()
            // .HasOne(p => p.Supplier)
            // .WithMany(s=> s.Products)
            // .HasForeignKey(p => p.SupplierId);

             builder.HasOne(p => p.Supplier)
               .WithMany(s => s.Products)
               .HasForeignKey(p => p.SupplierId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
