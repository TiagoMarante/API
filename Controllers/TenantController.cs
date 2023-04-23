using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[ApiController]
[Route("tenant")]
public class TenantController : ControllerBase
{
    private readonly ITenantServices _tenantServices;

    public TenantController(ITenantServices tenantServices)
    {
        _tenantServices = tenantServices;
    }

    [HttpGet]
    public async Task<ActionResult<OryonContentResponse<List<ClientResponse>>>> GetTenants()
    {
        var data = await _tenantServices.GetAll();
        return data.Data is null ? StatusCode(500) : Ok(data);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OryonContentResponse<ClientResponse>>> GetTenant(Guid id)
    {
        var data = await _tenantServices.GetById(id);
        return data.Data is null ? NotFound("Id not Found") : Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult<OryonContentResponse<ClientResponse>>> CreateTenant(CreateClientDto clientDto)
    {
        var data = await _tenantServices.Add(clientDto);
        return data.Data is null ? StatusCode(500) : Ok(data);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateTenant(Guid id, CreateClientDto clientDto)
    {
        var data = await _tenantServices.Update(id, clientDto);
        return data.Data is null ? NotFound("Id not Found") : Ok(data.Success);
    }


    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteTenant(Guid id)
    {
        var data = await _tenantServices.Delete(id);
        return data.Success is false ? NotFound("Id not Found") : Ok(data.Success);
    }
}