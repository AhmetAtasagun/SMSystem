using MediatR;
using Microsoft.AspNetCore.Identity;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Domain.Entities;

namespace SMSystem.Application.Features.Commands.Users.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILocalizationService _localizationService;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager, ILocalizationService localizationService)
        {
            _userManager = userManager;
            _localizationService = localizationService;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmPassword)
                return new RegisterUserCommandResponse().Error("Şifreler eşleşmiyor");

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                FullName = request.FullName,
                CreatedDate = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return new RegisterUserCommandResponse().Error(string.Join(", ", result.Errors.Select(e => e.Description)));

            return new RegisterUserCommandResponse().Success(user.Id, _localizationService.GetLocalizedString("UserRegistered"));
        }
    }
}