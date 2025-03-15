using SMSystem.Application.Repositories.CategoryRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.CategoryRepos
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
