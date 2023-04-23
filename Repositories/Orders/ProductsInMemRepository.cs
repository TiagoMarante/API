using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Repositories.Shared;

namespace Catalog.Repositories.Products;

public class OrdersInMemRepository : InMemEntityBaseRepository<Order>, IOrdersRepository
{
}