using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Services.Auth;
using SMSystem.Application.Services.Storage;
using SMSystem.Infrastructure.Auth;
using SMSystem.Infrastructure.Localization;
using SMSystem.Infrastructure.Storage;

namespace SMSystem.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<ILocalizationService, DbLocalizationService>();
            services.AddScoped<IFileService, LocalFileService>();
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}