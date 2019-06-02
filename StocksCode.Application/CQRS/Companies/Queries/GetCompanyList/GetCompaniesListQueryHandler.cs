using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StocksCode.Application.CQRS.Companies.Models;
using StocksCode.Application.Interfaces;
using StocksCode.Common.Helpers;

namespace StocksCode.Application.CQRS.Companies.Queries.GetCompanyList
{
    public class GetCompaniesListQueryHandler : IRequestHandler<GetCompaniesListQuery, HttpResponseHelper>
    {
        private readonly IMapper _mapper;
        private readonly IStocksCodeDbContext _context;

        public GetCompaniesListQueryHandler(IStocksCodeDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<HttpResponseHelper> Handle(GetCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var companies = await _context.Companies.ProjectTo<CompanyLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new HttpResponseHelper(companies, System.Net.HttpStatusCode.OK);

        }
    }
}
