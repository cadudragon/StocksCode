using System;
using Microsoft.EntityFrameworkCore;
using StocksCode.Application.Interfaces;
using StocksCode.Domain.Entities;

namespace StocksCode.Persistence
{
    public class StocksCodeDbContext: DbContext, IStocksCodeDbContext
    {
        public StocksCodeDbContext(DbContextOptions<StocksCodeDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Subsector> Subsectors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StocksCodeDbContext).Assembly);
        }
    }
}

