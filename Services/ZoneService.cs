using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Services;

public class ZoneService : IZoneServices
{

    private readonly IZonesRepository _zoneRepository;

    public ZoneService(IZonesRepository zoneRepository)
    {
        _zoneRepository = zoneRepository;
    }

    public async Task<OryonContentResponse<ZoneResponse>> CreateZone(CreateZoneDto zoneDto)
    {
        var isValid = ServicesRestrictions.validZones(zoneDto.Local!);
        try
        {
            if (!isValid) throw new ArgumentException();

            Zone newZone = new()
            {
                Local = zoneDto.Local,
                Price = zoneDto.Price
            };

            var result = await _zoneRepository.Add(newZone);
            if(result is null) throw new ArgumentException();

            return new OryonContentResponse<ZoneResponse>().SetSuccess(Utils.toDto(result), 1);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ZoneResponse>().SetFail(ex);
        }

        
    }

    public async Task<OryonContentResponse<ZoneResponse>> DeleteZone(Guid id)
    {
        try
        {
            var zone = await _zoneRepository.Get(id);
            if (zone is null) throw new ArgumentException();

            await _zoneRepository.Delete(id);
            var result = await _zoneRepository.Get(id);

            if (result != null) throw new ArgumentException();
            return new OryonContentResponse<ZoneResponse>().SetSuccess();
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ZoneResponse>().SetFail(ex);
        }
    }


    public async Task<OryonContentResponse<List<ZoneResponse>>> GetAllZones()
    {
        try
        {
            var result = await _zoneRepository.GetAll();
            if (result is null) throw new ArgumentException();

            return new OryonContentResponse<List<ZoneResponse>>().SetSuccess(Utils.toDto(result), result.Count);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<List<ZoneResponse>>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<ZoneResponse>> GetZone(Guid id)
    {
        try
        {
            var result = await _zoneRepository.Get(id);
            if (result is null) throw new ArgumentException();

            return new OryonContentResponse<ZoneResponse>().SetSuccess(Utils.toDto(result), 1);
        }
        catch (Exception ex)
        {   
            return new OryonContentResponse<ZoneResponse>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<ZoneResponse>> UpdateZone(Guid id, CreateZoneDto zoneDto)
    {
        try
        {
            var zone = await _zoneRepository.Get(id);
            if (zone is null) throw new ArgumentException("Zone not Found with that specific id");


            // Update Zone
            zone.Local = zoneDto.Local;
            zone.Price = zoneDto.Price;
            zone.Changed = DateTime.Now;

            await _zoneRepository.Update(zone);

            var result = await _zoneRepository.Get(id);
            if (result is null) throw new ArgumentException();

            return new OryonContentResponse<ZoneResponse>().SetSuccess(Utils.toDto(result), 1);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ZoneResponse>().SetFail(ex);
        }
    }



}