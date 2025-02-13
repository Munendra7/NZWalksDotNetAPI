using AutoMapper;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>();
            CreateMap<Region, RegionDTOV2>();
            CreateMap<Region, AddRegionDTO>();
            CreateMap<Region, UpdateRegionDTO>();
            CreateMap<Region, DeleteRegionDTO>();


            CreateMap<AddWalkDTO,Walk>();
            CreateMap<Walk,WalkDTO>();
            CreateMap<UpdateWalkDTO, Walk>();

            CreateMap<Difficulty,DifficultyDTO>();
        }
    }
}
