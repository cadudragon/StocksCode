using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StocksCode.Domain.Entities;

namespace StocksCode.Persistence.Configurations
{
    public class FundamentalConfiguration : IEntityTypeConfiguration<Fundamental>
    {
        public void Configure(EntityTypeBuilder<Fundamental> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        }
    }
}
