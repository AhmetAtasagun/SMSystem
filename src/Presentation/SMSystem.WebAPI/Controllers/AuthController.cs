using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMSystem.Application.Features.Commands.Users.LoginUser;
using SMSystem.Application.Features.Commands.Users.RefreshToken;
using SMSystem.Application.Features.Commands.Users.RegisterUser;
using SMSystem.Domain.Models.AuthModels;

namespace SMSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new RegisterUserCommandRequest
            {
                Email = model.Email,
                FullName = model.FullName,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new AuthResponse { IsSuccess = false, Message = result.Message });

            return Ok(new AuthResponse { IsSuccess = true, Message = result.Message });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new LoginUserCommandRequest
            {
                Email = model.Email,
                Password = model.Password
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new AuthResponse { IsSuccess = false, Message = result.Message });

            return Ok(new AuthResponse
            {
                IsSuccess = true,
                Token = result.Token,
                RefreshToken = result.RefreshToken,
                Expiration = result.Expiration,
                Message = result.Message
            });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new RefreshTokenCommandRequest
            {
                RefreshToken = model.RefreshToken
            };

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new AuthResponse { IsSuccess = false, Message = result.Message });

            return Ok(new AuthResponse
            {
                IsSuccess = true,
                Token = result.Token,
                RefreshToken = result.RefreshToken,
                Expiration = result.Expiration,
                Message = result.Message
            });
        }
    }
}
