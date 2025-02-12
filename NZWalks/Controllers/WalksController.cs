using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.CustomActionFilters;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber=1, [FromQuery] int pageSize=1000)
        {
            var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);

            //Map Domain Model to DTO


            return Ok(mapper.Map<List<WalkDTO>>(walksDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var walkDomainModel = await walkRepository.GetAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map domain model to DTO

            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkDTO addWalkDTO)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkDTO);

            walkDomainModel = await walkRepository.CreateAsync(walkDomainModel);

            //Map Domain Model To DTO
            var walkDTOModel = mapper.Map<WalkDTO>(walkDomainModel);

            return Ok(walkDTOModel);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWalkDTO updateWalkDTO)
        {
            //Map DTO to Domain Model

            var walkDomainModel = mapper.Map<Walk>(updateWalkDTO);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var walkDomianModel = await walkRepository.DeleteAsync(id);

            if (walkDomianModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDTO>(walkDomianModel));
        }
    }
}
