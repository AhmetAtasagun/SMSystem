using SMSystem.Application.Repositories.LocalizationRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;
using SMSystem.Persistance.Repositories;

namespace SMSystem.Persistance.Repositories.LocalizationRepos
{
    public class LocalizationReadRepository : ReadRepository<Localization>, ILocalizationReadRepository
    {
        public LocalizationReadRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}