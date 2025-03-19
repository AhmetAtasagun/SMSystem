using MediatR;

namespace SMSystem.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
    {
        public int Id { get; set; }
    }
}