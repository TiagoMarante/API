using Catalog.Dtos;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Interfaces.ServiceInterfaces;

public interface IZoneServices
{
    Task<OryonContentResponse<List<ZoneResponse>>> GetAllZones();
    Task<OryonContentResponse<ZoneResponse>> GetZone(Guid id);

    Task<OryonContentResponse<ZoneResponse>> CreateZone(CreateZoneDto zoneDto);

    Task<OryonContentResponse<ZoneResponse>> UpdateZone(Guid id, CreateZoneDto zoneDto);

    Task<OryonContentResponse<ZoneResponse>> DeleteZone(Guid id);
}