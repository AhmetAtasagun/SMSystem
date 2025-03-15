using SMSystem.Application.Repositories.StockRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.StockRepos
{
    public class StockReadRepository : ReadRepository<Stock>, IStockReadRepository
    {
        public StockReadRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
