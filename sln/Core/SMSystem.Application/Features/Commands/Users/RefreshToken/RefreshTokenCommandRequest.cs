using MediatR;

namespace SMSystem.Application.Features.Commands.Users.RefreshToken
{
    public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}