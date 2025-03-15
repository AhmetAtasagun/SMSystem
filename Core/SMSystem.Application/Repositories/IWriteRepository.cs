using SMSystem.Domain.Entities.Common;

namespace SMSystem.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity entity, CancellationToken token = default!);
        Task<bool> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken token = default!);
        bool Update(TEntity entity);
        bool Delete(TEntity entity, CancellationToken token = default!);
        bool Delete(int id, CancellationToken token = default!);
        bool DeleteRange(IEnumerable<TEntity> entities);
        Task<int> SaveAsync(CancellationToken token = default!);
    }
}
