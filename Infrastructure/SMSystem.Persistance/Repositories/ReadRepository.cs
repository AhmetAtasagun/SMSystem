using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Repositories;
using SMSystem.Domain.Entities.Common;
using SMSystem.Persistance.Contexts;
using System.Linq.Expressions;

namespace SMSystem.Persistance.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SMSDbContext _dbContext;

        public ReadRepository(SMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public IQueryable<TEntity> GetAll() => Table.AsQueryable();

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression) => Table.Where(expression);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default)
            => await Table.Where(expression).FirstOrDefaultAsync(token);

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken token = default)
            => await Table.Where(w => w.Id == id).FirstOrDefaultAsync(token);

    }
}
