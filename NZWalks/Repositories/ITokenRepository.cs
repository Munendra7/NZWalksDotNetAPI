using Microsoft.AspNetCore.Identity;

namespace NZWalks.Repositories
{
    public interface ITokenRepository
    {
        string GenerateJSONWebToken(IdentityUser user, List<string> roles);
    }
}
