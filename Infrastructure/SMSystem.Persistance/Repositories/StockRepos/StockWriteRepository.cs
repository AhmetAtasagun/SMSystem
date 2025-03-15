using SMSystem.Application.Repositories.StockRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.StockRepos
{
    public class StockWriteRepository : WriteRepository<Stock>, IStockWriteRepository
    {
        public StockWriteRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
