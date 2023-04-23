using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Repositories.Shared;
using Catalog.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Repositories.Clients;

public class ClientsRepository : BaseBaseRepository<Client>, IClientRepository
{
    // In case to build custom methods for repository
    private readonly IMongoCollection<Client> _clientsCollection;
    
    public ClientsRepository(IOptions<MongoDbSettings> dataStoreDatabaseSettings) : 
        base(dataStoreDatabaseSettings, dataStoreDatabaseSettings.Value.ClientsCollectionName)
    {
        _clientsCollection = DataCollection;
    }


}