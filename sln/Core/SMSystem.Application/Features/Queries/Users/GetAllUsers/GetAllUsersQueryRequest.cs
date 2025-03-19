using MediatR;

namespace SMSystem.Application.Features.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryRequest : IRequest<GetAllUsersQueryResponse>
    {
        public int? UserId { get; set; }
    }
}