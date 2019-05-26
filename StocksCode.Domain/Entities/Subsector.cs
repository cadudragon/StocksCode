using System;
namespace StocksCode.Domain.Entities
{
    public class Subsector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
