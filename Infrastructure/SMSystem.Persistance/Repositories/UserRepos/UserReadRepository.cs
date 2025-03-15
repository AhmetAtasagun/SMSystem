using SMSystem.Application.Repositories.UserRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.UserRepos
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
