using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("products").HasKey(m => m.Id);
        builder.ToTable("products").HasIndex(m => m.Name).IsUnique();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(200);
    }
}
