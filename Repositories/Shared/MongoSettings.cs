using Catalog.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Repositories.Shared;

public abstract class MongoSettings<TEntity>
{
    public static IMongoCollection<TEntity> GetProperCollection(IOptions<MongoDbSettings> dataStoreDatabaseSettings, string collection)
    {
        IMongoCollection<TEntity> dataCollection = null!;
        
        var mongoClient = new MongoClient(
            dataStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            dataStoreDatabaseSettings.Value.DatabaseName);

        dataCollection = collection switch
        {
            "Items" => mongoDatabase.GetCollection<TEntity>(dataStoreDatabaseSettings.Value.ItemsCollectionName),
            "Users" => mongoDatabase.GetCollection<TEntity>(dataStoreDatabaseSettings.Value.UsersCollectionName),
            "Clients" => mongoDatabase.GetCollection<TEntity>(dataStoreDatabaseSettings.Value.ClientsCollectionName),
            "Zones" => mongoDatabase.GetCollection<TEntity>(dataStoreDatabaseSettings.Value.ZonesCollectionName),
            "Products" => mongoDatabase.GetCollection<TEntity>(dataStoreDatabaseSettings.Value.ProductsCollectionName),
            "Orders" => mongoDatabase.GetCollection<TEntity>(dataStoreDatabaseSettings.Value.OrdersCollectionName),
            _ => dataCollection
        };

        return dataCollection;
    }
}