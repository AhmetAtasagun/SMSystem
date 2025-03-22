using SMSystem.Application.Repositories.UserRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories.UserRepos
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}
