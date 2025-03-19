using SMSystem.Application.Repositories.RefreshTokenRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;
using SMSystem.Persistance.Repositories;

namespace SMSystem.Persistance.Repositories.RefreshTokenRepos
{
    public class RefreshTokenWriteRepository : WriteRepository<RefreshToken>, IRefreshTokenWriteRepository
    {
        public RefreshTokenWriteRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}