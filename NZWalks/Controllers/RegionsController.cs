using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.CustomActionFilters;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NZWalksDbContext dbContext,IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAll()
        {
           //Get data from database - Domain Models
           //var regions = await dbContext.Regions.ToListAsync();

            var regions = await regionRepository.GetAllAsync();

            //Map Domain Models to DTOs
           var regionsDTO = mapper.Map<List<RegionDTO>>(regions);

           // Return DTOs
           return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var region = await regionRepository.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }
    
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddRegionDTO addRegionDto)
        {
            var regionDomainModel = new Region
            {
                Code = addRegionDto.Code,
                Name = addRegionDto.Name,
                RegionImageProperty = addRegionDto.RegionImageProperty
            };

            //await dbContext.Regions.AddAsync(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            //Map Domain Models to DTOs
            var regionsDTO = mapper.Map<AddRegionDTO>(regionDomainModel);

            return CreatedAtAction(nameof(Get), new { id = regionDomainModel.Id }, regionsDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO regionUpdateDTO)
        {
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            //if(regionDomainModel == null)
            //{
            //    return NotFound();
            //}

            //regionDomainModel.Code = regionUpdateDTO.Code;
            //regionDomainModel.Name = regionUpdateDTO.Name;
            //regionDomainModel.RegionImageProperty = regionUpdateDTO.RegionImageProperty;

            //await dbContext.SaveChangesAsync();

            var regionDomainModel = new Region
            {
                Code = regionUpdateDTO.Code,
                Name = regionUpdateDTO.Name,
                RegionImageProperty = regionUpdateDTO.RegionImageProperty
            };

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            //Map Domain Models to DTOs
            var regionDTO = mapper.Map<UpdateRegionDTO>(regionDomainModel);

            return Ok(regionDTO);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            //if (regionDomainModel == null)
            //{
            //    return NotFound();
            //}

            //dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            var regionDomainModel = await regionRepository.DeleteAsync(id);

            //Map Domain Models to DTOs
            var regionDTO = mapper.Map<DeleteRegionDTO>(regionDomainModel);

            return Ok(regionDTO);
        }
    }
}
