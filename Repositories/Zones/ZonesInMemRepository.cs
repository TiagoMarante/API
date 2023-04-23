using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Repositories.Shared;

namespace Catalog.Repositories.Clients;

public class ZonesInMemRepository : InMemEntityBaseRepository<Zone>, IZonesRepository
{
}