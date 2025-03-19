using SMSystem.Application.Repositories.InventoryRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.InventoryRepos
{
    public class InventoryReadRepository : ReadRepository<Inventory>, IInventoryReadRepository
    {
        public InventoryReadRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}