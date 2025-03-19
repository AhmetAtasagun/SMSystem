using SMSystem.Domain.Models;
using SMSystem.Domain.Models.AuthModels;

namespace SMSystem.Application.Features.Commands.Users.LoginUser
{
    public class LoginUserCommandResponse : HandleResult<LoginUserCommandResponse>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? Expiration { get; set; }
    }
}