using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Difficulties
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("312c3022-95cb-4749-a0e7-814c5c8b3e9b"),
                    Name="Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("5f59e1cc-1105-45b4-91ed-3a82011ebea1"),
                    Name="Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("24d5e56f-673a-49e1-b772-bd48d02f6161"),
                    Name="Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            // Seed Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("c888e272-d9cd-493b-8a01-e96d28e4beb0"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageProperty = "https://example.com/images/auckland.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("5a8e078f-9b8f-4abd-bae8-e4b3dc200725"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageProperty = "https://example.com/images/wellington.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("bb4ec9d4-79b9-47ba-83f2-8bfe04a014f3"),
                    Name = "Christchurch",
                    Code = "CHC",
                    RegionImageProperty = "https://example.com/images/christchurch.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("4a87771b-4d56-491e-8a39-b5bb81b364f0"),
                    Name = "Dunedin",
                    Code = "DUD",
                    RegionImageProperty = "https://example.com/images/dunedin.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("e1a22c36-2e7b-411d-a1aa-2cfd5f80c16d"),
                    Name = "Hamilton",
                    Code = "HAM",
                    RegionImageProperty = "https://example.com/images/hamilton.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("21b657dc-bb98-4cc1-9758-0837c9e9cd64"),
                    Name = "Tauranga",
                    Code = "TRG",
                    RegionImageProperty = "https://example.com/images/tauranga.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("f8a943ff-6c5a-4b28-b32e-2218145f0e47"),
                    Name = "Napier",
                    Code = "NPE",
                    RegionImageProperty = "https://example.com/images/napier.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("53c87fdf-f8e2-4b3b-8bb6-33d4913f7dcd"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageProperty = "https://example.com/images/nelson.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("3c8147da-7de1-4b88-9419-c18e38979d24"),
                    Name = "Palmerston North",
                    Code = "PMR",
                    RegionImageProperty = "https://example.com/images/palmerston-north.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("981b4ed7-b0f2-4cbb-a447-76ed1e1fba4c"),
                    Name = "Invercargill",
                    Code = "IVC",
                    RegionImageProperty = "https://example.com/images/invercargill.jpg"
                }
            };


            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
