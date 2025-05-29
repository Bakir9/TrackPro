using Core.Entities;
using System.Security.Claims;

namespace Core.Interfaces
{
    public interface ITokenService
    {
       string CreateTokenAsync(User user);
       string GenerateRefreshToken();

       ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token);
    }
}