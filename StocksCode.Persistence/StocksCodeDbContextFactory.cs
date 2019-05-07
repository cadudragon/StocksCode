using System;
using Microsoft.EntityFrameworkCore;
using StocksCode.Persistence.Infrastructure;

namespace StocksCode.Persistence
{
    public class StocksCodeDbContextFactory : DesignTimeDbContextFactoryBase<StocksCodeDbContext>
    {
        protected override StocksCodeDbContext CreateNewInstance(DbContextOptions<StocksCodeDbContext> options)
        {
            return new StocksCodeDbContext(options);
        }
    }
}