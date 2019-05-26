using System;
using System.Collections.Generic;

namespace StocksCode.Domain.Entities
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Subsector> Subsectors { get; set; }
    }
}
