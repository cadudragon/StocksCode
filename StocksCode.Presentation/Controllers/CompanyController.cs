using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StocksCode.Application.CQRS.Companies.Models;
using StocksCode.Application.CQRS.Companies.Queries.GetCompanyList;
using StocksCode.Application.Interfaces;
using StocksCode.Domain.Entities;

namespace StocksCode.Presentation.Controllers
{
    public class CompanyController : BaseController
    {

        public async Task<ActionResult<CompaniesListViewModel>> GetAll()
        {
            var response = await Mediator.Send(new GetCompaniesListQuery());
            return response.GetObjectResult();
        }


        //private readonly IStocksCodeDbContext _context;

        //public CompanyController(IStocksCodeDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IActionResult> PostSector([FromBody] SectorDTO sector)
        //{
        //    await _context.Sectors.AddAsync(new Sector { Name = sector.Name });
        //    await _context.SaveChangesAsync(new CancellationToken());
        //    return Ok();
        //}

        //public async Task<IActionResult> GetSector()
        //{
        //    var sectorList = await _context.Sectors.Include(p => p.Subsectors).Select(x => new
        //    {
        //        x.Id,
        //        x.Name,
        //        x.Subsectors
        //    }).ToListAsync();



        //    return Ok(JsonConvert.SerializeObject(sectorList));

        //}

        //public async Task<IActionResult> PostSubsector([FromBody] SubsectorDTO subsector)
        //{

        //    var sector = await _context.Sectors.FirstOrDefaultAsync(x => x.Id == subsector.SectorId);

        //    await _context.Subsectors.AddAsync(new Subsector
        //    {
        //        Name = subsector.Name,
        //        SectorId = subsector.SectorId,
        //        Sector = sector
        //    });
        //    await _context.SaveChangesAsync(new CancellationToken());
        //    return Ok();
        //}


        //public async Task<IActionResult> PostCompany([FromBody] CompanyDTO companyDTO)
        //{

        //    await _context.Companies.AddAsync(new Company
        //    {
        //        Name = companyDTO.Name,
        //        SubsectorId = companyDTO.SubsectorId,
        //        Symbol = companyDTO.Symbol,
        //        Website = companyDTO.Website
        //    });

        //    await _context.SaveChangesAsync(new CancellationToken());

        //    return Ok();
        //}

        //public async Task<IActionResult> GetCompany()
        //{
        //    var companies = await _context.Companies.Select(x => new { x.Id, x.Name, x.Website, x.SubsectorId, x.Symbol }).ToListAsync();

        //    return Ok(JsonConvert.SerializeObject(companies));

        //}
    }


    //public class SectorDTO
    //{
    //    public string Name { get; set; }
    //}

    //public class SubsectorDTO
    //{
    //    public string Name { get; set; }
    //    public int SectorId { get; set; }
    //}

    //public class CompanyDTO
    //{
    //    public int Id { get; set; }
    //    public string Symbol { get; set; }
    //    public string Name { get; set; }
    //    public string Website { get; set; }
    //    public int SubsectorId { get; set; }
    //    public virtual Subsector Subsector { get; set; }
    //}

}
