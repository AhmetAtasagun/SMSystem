using System;

namespace SMSystem.Application.Services.Auth
{
    public interface ICurrentUserService
    {
        int GetCurrentUserId();
    }
}