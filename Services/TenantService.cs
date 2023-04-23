using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Interfaces.ServiceInterfaces;

namespace Catalog.Services;

public class TenantService : ITenantServices
{
    private readonly ITenantRepository _tenantRepository;

    public TenantService(ITenantRepository tenantRepository, IZonesRepository zoneRepository)
    {
        _tenantRepository = tenantRepository;
    }


    public Task<OryonContentResponse<List<Tenant>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<OryonContentResponse<Tenant>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<OryonContentResponse<Tenant>> Add(dynamic dto)
    {
        throw new NotImplementedException();
    }

    public Task<OryonContentResponse<Tenant>> Update(Guid id, dynamic dto)
    {
        throw new NotImplementedException();
    }

    public Task<OryonContentResponse<Tenant>> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}