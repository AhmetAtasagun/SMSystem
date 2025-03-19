using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Repositories.UserRepos;
using SMSystem.Domain.Dtos;

namespace SMSystem.Application.Features.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var usersQuery = _userReadRepository.GetAll();

            if (request.UserId.HasValue)
            {
                usersQuery = usersQuery.Where(w => w.Id == request.UserId);
            }

            var users = await usersQuery
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetAllUsersQueryResponse().Success(users);
        }
    }
}