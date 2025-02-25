﻿namespace NZWalks.Models.DTO
{
    public class RegionDTO
    {
        public Guid Id { get; set; }

        public required string Code { get; set; }

        public required string Name { get; set; }

        public string? RegionImageProperty { get; set; }
    }

    public class RegionDTOV2
    {
        public Guid Id { get; set; }

        public required string Code { get; set; }

        public required string Name { get; set; }
    }
}
