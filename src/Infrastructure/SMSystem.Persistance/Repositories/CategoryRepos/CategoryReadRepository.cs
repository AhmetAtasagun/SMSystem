using SMSystem.Application.Repositories.CategoryRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.CategoryRepos
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
