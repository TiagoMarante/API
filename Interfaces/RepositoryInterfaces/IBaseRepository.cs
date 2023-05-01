using System.Linq.Expressions;

namespace Catalog.Interfaces.RepositoryInterfaces;

public interface IBaseRepository<TEntity>
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> Get(Guid id);
    Task<TEntity?> Find(Expression<Func<TEntity, bool>> filter);
    Task<TEntity?> Add(TEntity newItem);
    Task Update(TEntity obj);
    Task Delete(Guid id);
}