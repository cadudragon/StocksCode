using System;
using Microsoft.EntityFrameworkCore;
using StocksCode.Domain.Entities;

namespace StocksCode.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(p => p.Username).IsUnique();
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.Email).IsRequired();
        }
    }
}
