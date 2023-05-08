using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Repositories.Shared;
using Catalog.Settings;
using Microsoft.Extensions.Options;

namespace Catalog.Repositories.Clients;

public class ProductsRepository : BaseRepository<Product>, IProductRepository
{
    public ProductsRepository(IOptions<MongoDbSettings> dataStoreDatabaseSettings) : 
        base(dataStoreDatabaseSettings, dataStoreDatabaseSettings.Value.ProductsCollectionName)
    {
    }


}