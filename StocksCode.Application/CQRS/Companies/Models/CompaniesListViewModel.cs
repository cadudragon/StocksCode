using System;
using System.Collections.Generic;

namespace StocksCode.Application.CQRS.Companies.Models
{
    public class CompaniesListViewModel
    {
        public IList<CompanyLookupModel> Customers { get; set; }
    }
}
