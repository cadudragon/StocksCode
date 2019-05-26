using System;
using Microsoft.EntityFrameworkCore;
using StocksCode.Domain.Entities;

namespace StocksCode.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Company> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
            builder.Property(p => p.Symbol).IsRequired();
            builder.HasIndex(p => p.Symbol).IsUnique();
        }
    }
}
