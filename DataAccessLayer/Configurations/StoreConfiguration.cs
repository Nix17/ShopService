using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations;

public class StoreConfiguration : IEntityTypeConfiguration<StoreEntity>
{
    public void Configure(EntityTypeBuilder<StoreEntity> builder)
    {
        builder.ToTable("stores").HasKey(m => m.Id);
        // Добавляем автоинкрементное свойство Id
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(256);
        builder.Property(m => m.Address).HasDefaultValue("").HasMaxLength(500);
    }
}
