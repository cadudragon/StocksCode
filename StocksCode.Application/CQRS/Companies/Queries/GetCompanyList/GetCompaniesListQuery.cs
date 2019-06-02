using System;
using MediatR;
using StocksCode.Application.CQRS.Companies.Models;
using StocksCode.Common.Helpers;

namespace StocksCode.Application.CQRS.Companies.Queries.GetCompanyList
{
    public class GetCompaniesListQuery : IRequest<HttpResponseHelper>
    {

    }
}
