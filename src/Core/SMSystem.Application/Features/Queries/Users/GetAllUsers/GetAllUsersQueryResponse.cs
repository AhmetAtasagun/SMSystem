using SMSystem.Domain.Dtos;
using SMSystem.Domain.Models;

namespace SMSystem.Application.Features.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryResponse : HandleDataResult<GetAllUsersQueryResponse, List<UserDto>>
    {
    }
}