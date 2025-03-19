using SMSystem.Application.Repositories.ProductRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.ProductRepos
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
