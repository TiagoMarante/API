using Catalog.Dtos;
using Catalog.Dtos.Create;
using Catalog.Dtos.Response.Tenant;
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


    public async Task<OryonContentResponse<List<TenantResponse>>> GetAll()
    {
        try
        {
            var result = await _tenantRepository.GetAll();
            if (result is null) throw new ArgumentException();

            return new OryonContentResponse<List<TenantResponse>>().SetSuccess(result.Select(x => x.ToDto()).ToList(),
                result.Count);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<List<TenantResponse>>().SetFail(ex);
        }
    }

    public Task<OryonContentResponse<TenantResponse>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<OryonContentResponse<TenantResponse>> Add(dynamic dto)
    {
        try
        {
            //validate if exist with same name
            var tenantDto = (CreateTenantDto)dto;
            var x = await _tenantRepository.Find(x => x.Name == tenantDto.TenantName);
            //nested list var y = await _tenantRepository.Find(x => x.Users.Any(x => x.Id.ToString() == tenantDto.TenantName));

            if (x != null) throw new ArgumentException("Tenant with that name exist");

            var newTenant = new Tenant((CreateTenantDto)dto);
            var result = await _tenantRepository.Add(newTenant);
            if (result is null) throw new ArgumentException("Error while creating Tenant");

            return new OryonContentResponse<TenantResponse>().SetSuccess(newTenant.ToDto(), 1);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<TenantResponse>().SetFail(ex);
        }
    }

    public Task<OryonContentResponse<TenantResponse>> Update(Guid id, dynamic dto)
    {
        throw new NotImplementedException();
    }

    public Task<OryonContentResponse<TenantResponse>> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}