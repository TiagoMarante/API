using Catalog.Entities;
using Catalog.Interfaces;

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

    public Task<List<TEntity>> GetAll()
    {
        return Task.FromResult(Data);
    }

    public async Task Update(TEntity obj)
    {
        var userDb = await Get(obj.Id);

        if (userDb != null) Data.Remove(userDb);
        Data.Add(obj);
    }
}