using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetAsync(Guid id)
        {
            var walkDomainModel = await dbContext.Walks.FindAsync(id);

            if(walkDomainModel==null)
            {
                return null;
            }

            return walkDomainModel;
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var walkDomainModel = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (walkDomainModel == null)
            {
                return null;
            }

            walkDomainModel.Name = walk.Name;
            walkDomainModel.WalkImageURL = walk.WalkImageURL;
            walkDomainModel.Description = walk.Description;
            walkDomainModel.DifficultyId = walk.DifficultyId;
            walkDomainModel.RegionId = walk.RegionId;
            walkDomainModel.LengthInKM = walk.LengthInKM;

            await dbContext.SaveChangesAsync();

            return walkDomainModel;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walkDomainModel = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (walkDomainModel == null)
            {
                return null;
            }

            dbContext.Walks.Remove(walkDomainModel);
            await dbContext.SaveChangesAsync();

            return walkDomainModel;
        }
    }
}
