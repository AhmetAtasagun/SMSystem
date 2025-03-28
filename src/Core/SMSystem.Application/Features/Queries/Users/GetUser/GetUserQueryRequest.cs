using MediatR;

namespace SMSystem.Application.Features.Queries.Users.GetUser
{
    public class GetUserQueryRequest : IRequest<GetUserQueryResponse>
    {
        public int Id { get; set; }
    }
}