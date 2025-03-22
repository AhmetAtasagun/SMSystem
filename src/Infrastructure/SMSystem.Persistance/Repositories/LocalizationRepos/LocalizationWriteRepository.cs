using SMSystem.Application.Repositories.LocalizationRepos;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Contexts;
using SMSystem.Persistance.Repositories;

namespace SMSystem.Persistance.Repositories.LocalizationRepos
{
    public class LocalizationWriteRepository : WriteRepository<Localization>, ILocalizationWriteRepository
    {
        public LocalizationWriteRepository(SMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}