using SMSystem.Domain.Models;

namespace SMSystem.Application.Features.Commands.Users.RefreshToken
{
    public class RefreshTokenCommandResponse : HandleResult<RefreshTokenCommandResponse>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? Expiration { get; set; }
    }
}