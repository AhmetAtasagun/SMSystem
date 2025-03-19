using SMSystem.Application.Repositories.InventoryRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.InventoryRepos
{
    public class InventoryWriteRepository : WriteRepository<Inventory>, IInventoryWriteRepository
    {
        public InventoryWriteRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}