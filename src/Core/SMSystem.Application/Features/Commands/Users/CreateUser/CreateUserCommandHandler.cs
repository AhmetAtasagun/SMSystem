using AutoMapper;
using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.UserRepos;
using SMSystem.Domain.Entities;

namespace SMSystem.Application.Features.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public CreateUserCommandHandler(IUserWriteRepository userWriteRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _userWriteRepository = userWriteRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            var result = await _userWriteRepository.AddAsync(user, cancellationToken);
            await _userWriteRepository.SaveAsync(cancellationToken);

            // TODO : Kullanıcı Rol ekleme ve Hashing işlemleri yapılacak

            return result ?
                new CreateUserCommandResponse().Success(user.Id, _localizationService.GetLocalizedString("UserCreated")) :
                new CreateUserCommandResponse().Error(_localizationService.GetLocalizedString("UserCreateError"));
        }
    }
}