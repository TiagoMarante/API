using System.Linq.Expressions;
using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;

namespace Catalog.Repositories.Shared;

public class InMemEntityBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
{
    private List<TEntity> Data { get; } = new()
    {
    };


    public Task<TEntity?> Add(TEntity obj)
    {
        Data.Add(obj);
        var objCreated = Data.Contains(obj);
        return Task.FromResult(objCreated ? obj : null);
    }

    public async Task Delete(Guid id)
    {
        var obj = await Get(id);
        if (obj != null) Data.Remove(obj);
    }

    public Task<TEntity?> Get(Guid id)
    {
        var item = Data.SingleOrDefault(elem => elem.Id == id);
        return Task.FromResult(item);
    }

    public Task<TEntity?> Find(Expression<Func<TEntity, bool>> filter)
    {
        var items = Data.AsEnumerable().Where(filter.Compile()).FirstOrDefault();
        return Task.FromResult(items);
    }

    public Task<List<TEntity>> GetAll()
    {
        return Task.FromResult(Data);
    }

    public async Task Update(TEntity obj)
    {
        var item = await Get(obj.Id);

        if (item != null) Data.Remove(item);
        Data.Add(obj);
    }
}