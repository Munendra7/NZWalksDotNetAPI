﻿namespace NZWalks.Models.DTO
{
    public class UpdateRegionDTO
    {
        public required string Code { get; set; }

        public required string Name { get; set; }

        public string? RegionImageProperty { get; set; }
    }
}
