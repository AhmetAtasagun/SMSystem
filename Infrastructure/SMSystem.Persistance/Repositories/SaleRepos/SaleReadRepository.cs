using SMSystem.Application.Repositories.SaleRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.SaleRepos
{
    public class SaleReadRepository : ReadRepository<Sale>, ISaleReadRepository
    {
        public SaleReadRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
