using System;
using Microsoft.EntityFrameworkCore;
using StocksCode.Domain.Entities;

namespace StocksCode.Persistence.Configurations
{
    public class SubsectorConfiguration : IEntityTypeConfiguration<Subsector>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Subsector> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
