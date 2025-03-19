using AutoMapper;
using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.UserRepos;

namespace SMSystem.Application.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public UpdateUserCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                return new UpdateUserCommandResponse().Error(_localizationService.GetLocalizedString("UserNotFound"));

            user = _mapper.Map(request, user);

            // TODO : Kullanıcı Rol ekleme ve Hashing işlemleri yapılacak

            var result = _userWriteRepository.Update(user);
            await _userWriteRepository.SaveAsync(cancellationToken);

            return result ?
                new UpdateUserCommandResponse().Success(_localizationService.GetLocalizedString("UserUpdated")) :
                new UpdateUserCommandResponse().Error(_localizationService.GetLocalizedString("UserUpdateError"));
        }
    }
}