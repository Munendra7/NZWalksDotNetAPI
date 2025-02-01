namespace NZWalks.Models.DTO
{
    public class AddWalkDTO
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public double LengthInKM { get; set; }

        public string? WalkImageURL { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}
