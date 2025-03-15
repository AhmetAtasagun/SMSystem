using SMSystem.Application.Repositories.SaleRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.SaleRepos
{
    public class SaleWriteRepository : WriteRepository<Sale>, ISaleWriteRepository
    {
        public SaleWriteRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
