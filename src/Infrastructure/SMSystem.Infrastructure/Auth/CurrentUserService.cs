using Microsoft.AspNetCore.Http;
using SMSystem.Application.Services.Auth;
using System;
using System.Linq;
using System.Security.Claims;

namespace SMSystem.Infrastructure.Auth
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User is not authenticated");
            }

            if (int.TryParse(userId, out int id))
            {
                return id;
            }

            throw new InvalidOperationException("Invalid user ID format");
        }
    }
}