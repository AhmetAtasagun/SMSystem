using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Repositories;
using SMSystem.Domain.Entities.Common;
using SMSystem.Persistance.Contexts;

namespace SMSystem.Persistance.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SMSDbContext _dbContext;

        public WriteRepository(SMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity entity, CancellationToken token = default)
        {
            var status = await Table.AddAsync(entity, token);
            return status.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken token = default)
        {
            await Table.AddRangeAsync(entities, token);
            return true;
        }

        public bool Delete(TEntity entity, CancellationToken token = default)
        {
            var status = Table.Remove(entity);
            return status.State == EntityState.Deleted;
        }

        public bool Delete(int id, CancellationToken token = default)
        {
            var entity = Table.Find(id);
            return Delete(entity);
        }

        public bool DeleteRange(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public bool Update(TEntity entity)
        {
            var status = Table.Update(entity);
            return status.State == EntityState.Modified;
        }

        public Task<int> SaveAsync(CancellationToken token = default)
        {
            return _dbContext.SaveChangesAsync(token);
        }
    }
}
