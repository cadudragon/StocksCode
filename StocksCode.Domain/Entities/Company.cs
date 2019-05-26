using System;
namespace StocksCode.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public int SubsectorId { get; set; }
        public virtual Subsector Subsector { get; set; }
    }
}
