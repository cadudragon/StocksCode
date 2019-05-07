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

        public DbSet<Fundamental> Fundamentals { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StocksCodeDbContext).Assembly);
        }
    }
}

