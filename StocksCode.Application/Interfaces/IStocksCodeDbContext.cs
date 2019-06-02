using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StocksCode.Domain.Entities;

namespace StocksCode.Application.Interfaces
{
    public interface IStocksCodeDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Sector> Sectors { get; set; }
        DbSet<Subsector> Subsectors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
