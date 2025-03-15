using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMSystem.Application.Repositories.CategoryRepos;
using SMSystem.Application.Repositories.ProductRepos;
using SMSystem.Application.Repositories.SaleRepos;
using SMSystem.Application.Repositories.StockRepos;
using SMSystem.Application.Repositories.UserRepos;
using SMSystem.Persistance.Contexts;
using SMSystem.Persistance.Repositories.CategoryRepos;
using SMSystem.Persistance.Repositories.ProductRepos;
using SMSystem.Persistance.Repositories.SaleRepos;
using SMSystem.Persistance.Repositories.StockRepos;
using SMSystem.Persistance.Repositories.UserRepos;

namespace SMSystem.Persistance
{
    public static class ServiceRegistrations
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SMSDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SMSDbConnection"));
            }, ServiceLifetime.Singleton);
            services.AddSingleton<ICategoryReadRepository, CategoryReadRepository>();
            services.AddSingleton<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
            services.AddSingleton<ISaleReadRepository, SaleReadRepository>();
            services.AddSingleton<ISaleWriteRepository, SaleWriteRepository>();
            services.AddSingleton<IStockReadRepository, StockReadRepository>();
            services.AddSingleton<IStockWriteRepository, StockWriteRepository>();
            services.AddSingleton<IUserReadRepository, UserReadRepository>();
            services.AddSingleton<IUserWriteRepository, UserWriteRepository>();
        }
    }
}
