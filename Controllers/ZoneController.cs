using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;


[ApiController]
[Route("zone")]
public class ZoneController : ControllerBase
{
    private readonly IZoneServices _zoneService;

    public ZoneController(IZoneServices zoneServices)
    {
        _zoneService = zoneServices;
    }



    [HttpGet]
    public async Task<ActionResult<OryonContentResponse<List<ZoneResponse>>>> GetAllZones()
    {
        var zones = await _zoneService.GetAllZones();
        return zones.Data is null ? StatusCode(500) : Ok(zones);
    }


    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OryonContentResponse<ZoneResponse>>> GetZone(Guid id)
    {
        var zone = await _zoneService.GetZone(id);
        return zone.Data is null ? NotFound("Id not Found") : Ok(zone);
    }

    [HttpPost]
    public async Task<ActionResult<OryonContentResponse<ZoneResponse>>> CreateZone(CreateZoneDto zoneDto)
    {
        var createZone = await _zoneService.CreateZone(zoneDto);
        return createZone.Data is null ? StatusCode(500) : Ok(createZone);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateZone(Guid id, CreateZoneDto zoneDto)
    {
        var updateZone = await _zoneService.UpdateZone(id, zoneDto);
        return updateZone.Data is null ? NotFound("Id not Found") : Ok(updateZone.Success);
    }


    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteZone(Guid id)
    {
        var deleteZone = await _zoneService.DeleteZone(id);
        return deleteZone.Data is null ? NotFound("Id not Found") : Ok(deleteZone.Success);
    }
}