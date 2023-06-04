using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Interfaces.ServiceInterfaces;

namespace Catalog.Services;

public class BaseService : IBaseService<Client>
{
    public Task<OryonContentResponse<List<Client>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<OryonContentResponse<Client>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<OryonContentResponse<Client>> Add(dynamic dto)
    {
        throw new NotImplementedException();
    }

    public Task<OryonContentResponse<Client>> Update(Guid id, dynamic dto)
    {
        throw new NotImplementedException();
    }

    public Task<OryonContentResponse<Client>> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}