using SMSystem.Domain.Entities.Common;
using System.Linq.Expressions;

namespace SMSystem.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default!);
        Task<TEntity> GetByIdAsync(int id, CancellationToken token = default!);

    }
}
