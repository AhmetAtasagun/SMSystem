using SMSystem.Application.Repositories.ProductRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.ProductRepos
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
