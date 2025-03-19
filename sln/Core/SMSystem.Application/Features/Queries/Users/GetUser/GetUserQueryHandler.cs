using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.UserRepos;
using SMSystem.Domain.Dtos;

namespace SMSystem.Application.Features.Queries.Users.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public GetUserQueryHandler(IUserReadRepository userReadRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _userReadRepository = userReadRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetAll()
                .Where(u => u.Id == request.Id)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

            return user == null ?
                new GetUserQueryResponse().Error(_localizationService.GetLocalizedString("UserNotFound")) :
                new GetUserQueryResponse().Success(user);
        }
    }
}