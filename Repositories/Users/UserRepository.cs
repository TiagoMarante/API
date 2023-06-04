using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Repositories.Shared;
using Catalog.Settings;
using Microsoft.Extensions.Options;

namespace Catalog.Repositories.Tenants;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IOptions<MongoDbSettings> dataStoreDatabaseSettings) :
        base(dataStoreDatabaseSettings, dataStoreDatabaseSettings.Value.TenantsCollectionName)
    {
    }
}