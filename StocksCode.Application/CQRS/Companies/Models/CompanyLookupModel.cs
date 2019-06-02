using System;
using AutoMapper;
using StocksCode.Application.Interfaces.Mapping;
using StocksCode.Domain.Entities;

namespace StocksCode.Application.CQRS.Companies.Models
{
    public class CompanyLookupModel : IHaveCustomMapping
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Company, CompanyLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.Name, opt => opt.MapFrom(c => c.Name));
        }
    }
}
