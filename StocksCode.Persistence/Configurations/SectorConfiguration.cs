using System;
using Microsoft.EntityFrameworkCore;
using StocksCode.Domain.Entities;

namespace StocksCode.Persistence.Configurations
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Sector> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();

            //builder.HasMany(p => p.Subsectors)
                //.WithOne(p => p.Sector);
        }
    }
}
