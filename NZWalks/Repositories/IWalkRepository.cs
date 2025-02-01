using NZWalks.Models.Domain;

namespace NZWalks.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);

        Task<List<Walk>> GetAllAsync();

        Task<Walk?> GetAsync(Guid id);

        Task<Walk?> UpdateAsync(Guid id, Walk region);

        Task<Walk?> DeleteAsync(Guid id);
    }
}
