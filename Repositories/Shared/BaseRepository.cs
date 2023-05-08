using System.Linq.Expressions;
using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Repositories.Shared;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
{
    protected IMongoCollection<TEntity> DataCollection { get; }


    protected BaseRepository(IOptions<MongoDbSettings> dataStoreDatabaseSettings, string collection)
    {
        DataCollection = MongoSettings<TEntity>.GetProperCollection(dataStoreDatabaseSettings, collection);
    }


    public async Task<List<TEntity>> GetAll()
    {
        var data = await DataCollection.Find(_ => true).ToListAsync();
        return data;
    }

    public async Task<TEntity?> Get(Guid id)
    {
        var data = await DataCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return data;
    }

    public async Task<TEntity?> Find(Expression<Func<TEntity,bool>> filter)
    {
        var data = await DataCollection.Find(filter).FirstOrDefaultAsync();
        return data;
    }

    public async Task<TEntity?> Add(TEntity newData)
    {
        await DataCollection.InsertOneAsync(newData);
        var dataCreated = await Get(newData.Id);
        return dataCreated ?? null;
    }


    public async Task Update(TEntity updatedData)
    {
        var id = updatedData.Id;
        await DataCollection.ReplaceOneAsync(x => x.Id == id, updatedData);
    }


    public async Task Delete(Guid id)
    {
        await DataCollection.DeleteOneAsync(x => x.Id == id);
    }
}