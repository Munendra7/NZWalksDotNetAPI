namespace NZWalks.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public double LengthInKM { get; set; }

        public string? WalkImageURL { get; set; }

        public Guid DifficultyId { get; set; }

        public Guid RegionId { get; set; }


        // Navigation Property
        public required Difficulty Difficulty { get; set; }

        public required Region Region { get; set; }
    }
}
