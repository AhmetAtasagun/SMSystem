using SMSystem.Application.Repositories.RefreshTokenRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;
using SMSystem.Persistance.Repositories;

namespace SMSystem.Persistance.Repositories.RefreshTokenRepos
{
    public class RefreshTokenReadRepository : ReadRepository<RefreshToken>, IRefreshTokenReadRepository
    {
        public RefreshTokenReadRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}