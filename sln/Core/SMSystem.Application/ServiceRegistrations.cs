using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMSystem.Application.Mapping;

namespace SMSystem.Application
{
    public static class ServiceRegistrations
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceRegistrations).Assembly));
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
