using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.UserRepos;

namespace SMSystem.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly ILocalizationService _localizationService;

        public DeleteUserCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, ILocalizationService localizationService)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _localizationService = localizationService;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                return new DeleteUserCommandResponse().Error(_localizationService.GetLocalizedString("UserNotFound"));

            var result = _userWriteRepository.Delete(user, cancellationToken);
            await _userWriteRepository.SaveAsync(cancellationToken);

            return result ?
                new DeleteUserCommandResponse().Success(_localizationService.GetLocalizedString("UserDeleted")) :
                new DeleteUserCommandResponse().Error(_localizationService.GetLocalizedString("UserDeleteError"));
        }
    }
}