using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Repositories.Shared;

namespace Catalog.Repositories.Tenants;

public class UserRepositoryInMemRepository : InMemEntityBaseRepository<User>, IUserRepository
{
}