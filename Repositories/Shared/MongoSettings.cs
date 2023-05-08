using Catalog.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Repositories.Shared;

public abstract class MongoSettings<TEntity>
{
    public static IMongoCollection<TEntity> GetProperCollection(IOptions<MongoDbSettings> dataStoreDatabaseSettings, string collection)
    {
        var mongoClient = new MongoClient(dataStoreDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(dataStoreDatabaseSettings.Value.DatabaseName);
        var dataCollection = mongoDatabase.GetCollection<TEntity>(collection);

        return dataCollection;
    }
}