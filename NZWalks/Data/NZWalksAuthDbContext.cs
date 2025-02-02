using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.Data
{
    public class NZWalksAuthDbContext: IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "e81bd24d-d1f7-4d22-a098-bb3b910ef2d4",
                    ConcurrencyStamp = "e81bd24d-d1f7-4d22-a098-bb3b910ef2d4",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "27b347a7-22ca-419a-8daf-a24724344099 ​",
                    ConcurrencyStamp = "27b347a7-22ca-419a-8daf-a24724344099",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
