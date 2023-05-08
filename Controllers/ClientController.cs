using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

//TODO need to delete try catch from controller

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    private readonly IClientServices _clientServices;

    public ClientController(IClientServices clientServices)
    {
        _clientServices = clientServices;
    }

    //[Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<OryonContentResponse<List<ClientResponse>>>> GetClients()
    {
        var data = await _clientServices.GetAllClients();
        return data.Data is null ? StatusCode(500) : Ok(data);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OryonContentResponse<ClientResponse>>> GetClient(Guid id)
    {
        var data = await _clientServices.GetClient(id);
        return data.Data is null ? NotFound("Id not Found") : Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult<OryonContentResponse<ClientResponse>>> CreateClient(CreateClientDto clientDto)
    {
        var data = await _clientServices.CreateClient(clientDto);
        return data.Data is null ? StatusCode(500) : Ok(data);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateClient(Guid id, CreateClientDto clientDto)
    {
        var data = await _clientServices.UpdateClient(id, clientDto);
        return data.Data is null ? NotFound("Id not Found") : Ok(data.Success);
    }


    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteClient(Guid id)
    {
        var data = await _clientServices.DeleteClient(id);
        return data.Success is false ? NotFound("Id not Found") : Ok(data.Success);
    }
}