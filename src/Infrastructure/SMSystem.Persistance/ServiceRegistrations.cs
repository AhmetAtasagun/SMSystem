using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMSystem.Application.Repositories.CategoryRepos;
using SMSystem.Application.Repositories.LocalizationRepos;
using SMSystem.Application.Repositories.ProductRepos;
using SMSystem.Application.Repositories.RefreshTokenRepos;
using SMSystem.Application.Repositories.SaleRepos;
using SMSystem.Application.Repositories.InventoryRepos;
using SMSystem.Application.Repositories.UserRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;
using SMSystem.Persistance.Repositories.CategoryRepos;
using SMSystem.Persistance.Repositories.LocalizationRepos;
using SMSystem.Persistance.Repositories.ProductRepos;
using SMSystem.Persistance.Repositories.RefreshTokenRepos;
using SMSystem.Persistance.Repositories.SaleRepos;
using SMSystem.Persistance.Repositories.InventoryRepos;
using SMSystem.Persistance.Repositories.UserRepos;

namespace SMSystem.Persistance
{
    public static class ServiceRegistrations
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SMSDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SMSDbConnection"), b => b.MigrationsAssembly("SMSystem.Persistance"));
            }, ServiceLifetime.Scoped);

            // Identity yapılandırması
            services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<SMSDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<ISaleReadRepository, SaleReadRepository>();
            services.AddScoped<ISaleWriteRepository, SaleWriteRepository>();
            services.AddScoped<IInventoryReadRepository, InventoryReadRepository>();
            services.AddScoped<IInventoryWriteRepository, InventoryWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<ILocalizationReadRepository, LocalizationReadRepository>();
            services.AddScoped<ILocalizationWriteRepository, LocalizationWriteRepository>();
            services.AddScoped<IRefreshTokenReadRepository, RefreshTokenReadRepository>();
            services.AddScoped<IRefreshTokenWriteRepository, RefreshTokenWriteRepository>();
        }
    }
}
