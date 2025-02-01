namespace NZWalks.Models.DTO
{
    public class DeleteRegionDTO
    {
        public required string Code { get; set; }

        public required string Name { get; set; }

        public string? RegionImageProperty { get; set; }
    }
}
