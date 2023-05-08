using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Repositories.Shared;
using Catalog.Settings;
using Microsoft.Extensions.Options;

namespace Catalog.Repositories.Zones;

public class ZonesRepository : BaseRepository<Zone>, IZonesRepository
{
    public ZonesRepository(IOptions<MongoDbSettings> dataStoreDatabaseSettings) : 
        base(dataStoreDatabaseSettings, dataStoreDatabaseSettings.Value.ZonesCollectionName)
    {
    }


}