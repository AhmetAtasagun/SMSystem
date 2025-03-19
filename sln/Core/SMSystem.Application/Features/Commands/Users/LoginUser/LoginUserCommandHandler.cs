using MediatR;
using Microsoft.AspNetCore.Identity;
using SMSystem.Application.Repositories.RefreshTokenRepos;
using SMSystem.Application.Services.Auth;
using SMSystem.Domain.Entities;

// Tam nitelikli ad kullanarak RefreshToken sınıfını belirtiyoruz

namespace SMSystem.Application.Features.Commands.Users.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;

        public LoginUserCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtService jwtService, IRefreshTokenWriteRepository refreshTokenWriteRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _refreshTokenWriteRepository = refreshTokenWriteRepository;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return new LoginUserCommandResponse().Error("Geçersiz email veya şifre");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
                return new LoginUserCommandResponse().Error("Geçersiz email veya şifre");

            var token = _jwtService.GenerateJwtToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            // Refresh token'ı kaydet
            var refreshTokenEntity = new SMSystem.Domain.Entities.RefreshToken
            {
                UserId = user.Id,
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                CreatedDate = DateTime.UtcNow
            };

            // Save refresh token to database
            await _refreshTokenWriteRepository.AddAsync(refreshTokenEntity, cancellationToken);
            await _refreshTokenWriteRepository.SaveAsync(cancellationToken);

            return new LoginUserCommandResponse
            {
                IsSuccess = true,
                Message = "Giriş başarılı",
                Token = token,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddMinutes(60)
            };
        }
    }
}