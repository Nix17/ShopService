using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations;

public class ProductBatchConfiguration : IEntityTypeConfiguration<ProductBatchEntity>
{
    public void Configure(EntityTypeBuilder<ProductBatchEntity> builder)
    {
        builder.ToTable("product_batches").HasKey(m => m.Id);
        builder.ToTable("product_batches").HasIndex(m => m.ProductId);
        builder.ToTable("product_batches").HasIndex(m => m.StoreId);
        builder.Property(m => m.Quantity).HasDefaultValue(1).IsRequired();
        builder.Property(m => m.Price).IsRequired();
    }
}
