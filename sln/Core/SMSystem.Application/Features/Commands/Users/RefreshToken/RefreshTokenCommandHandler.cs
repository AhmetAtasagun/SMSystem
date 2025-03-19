using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Repositories.RefreshTokenRepos;
using SMSystem.Application.Services.Auth;
using SMSystem.Domain.Entities;
// Tam nitelikli ad kullanarak RefreshToken sınıfını belirtiyoruz

namespace SMSystem.Application.Features.Commands.Users.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenReadRepository _refreshTokenReadRepository;
        private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;

        public RefreshTokenCommandHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService, 
            IRefreshTokenReadRepository refreshTokenReadRepository, IRefreshTokenWriteRepository refreshTokenWriteRepository)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _refreshTokenReadRepository = refreshTokenReadRepository;
            _refreshTokenWriteRepository = refreshTokenWriteRepository;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.RefreshToken))
                return new RefreshTokenCommandResponse().Error("Geçersiz refresh token");

            try
            {
                // Find the refresh token in the database
                var storedRefreshToken = await _refreshTokenReadRepository.Where(r => 
                    r.Token == request.RefreshToken && 
                    !r.IsUsed && 
                    !r.IsRevoked && 
                    r.ExpiryDate > DateTime.UtcNow)
                    .FirstOrDefaultAsync(cancellationToken);
                
                if (storedRefreshToken == null)
                    return new RefreshTokenCommandResponse().Error("Geçersiz veya süresi dolmuş refresh token");
                
                // Get the user associated with the token
                var user = await _userManager.FindByIdAsync(storedRefreshToken.UserId.ToString());
                if (user == null)
                    return new RefreshTokenCommandResponse().Error("Kullanıcı bulunamadı");
                
                // Mark the current refresh token as used
                storedRefreshToken.IsUsed = true;
                _refreshTokenReadRepository.Table.Update(storedRefreshToken);
                
                // Generate new tokens
                var newToken = _jwtService.GenerateJwtToken(user);
                var newRefreshToken = _jwtService.GenerateRefreshToken();
                
                // Save the new refresh token
                var refreshTokenEntity = new SMSystem.Domain.Entities.RefreshToken
                {
                    UserId = user.Id,
                    Token = newRefreshToken,
                    ExpiryDate = DateTime.UtcNow.AddDays(7),
                    IsUsed = false,
                    IsRevoked = false
                };
                
                await _refreshTokenWriteRepository.AddAsync(refreshTokenEntity, cancellationToken);
                await _refreshTokenWriteRepository.SaveAsync(cancellationToken);
                
                return new RefreshTokenCommandResponse
                {
                    IsSuccess = true,
                    Message = "Token yenilendi",
                    Token = newToken,
                    RefreshToken = newRefreshToken,
                    Expiration = DateTime.UtcNow.AddMinutes(60)
                };
            }
            catch (Exception ex)
            {
                return new RefreshTokenCommandResponse().Error($"Token yenileme hatası: {ex.Message}");
            }
        }
    }
}