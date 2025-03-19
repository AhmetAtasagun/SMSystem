using SMSystem.Domain.Entities;

namespace SMSystem.Application.Services.Auth
{
    public interface IJwtService
    {
        string GenerateJwtToken(ApplicationUser user);
        string GenerateRefreshToken();
        string ValidateJwtToken(string token);
    }
}