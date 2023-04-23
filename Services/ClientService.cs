using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Interfaces.ServiceInterfaces;

namespace Catalog.Services;

public class ClientService : IClientServices
{

    private readonly IClientRepository _clientRepository;
    private readonly IZonesRepository _zoneRepository;

    public ClientService(IClientRepository clientRepository, IZonesRepository zoneRepository)
    {
        _clientRepository = clientRepository;
        _zoneRepository = zoneRepository;
    }

    public async Task<OryonContentResponse<ClientResponse>> CreateClient(CreateClientDto clientDto)
    {
        try
        {
            //TODO unique email

            var isValid = ServicesRestrictions.validClient(clientDto.Type!);
            if(!isValid) throw new ArgumentException();

            #region Validating Zone
            var zone = await _zoneRepository.Get(clientDto.ZoneId);
            if (zone is null) throw new ArgumentException();
            #endregion

            #region Validating Clients and Incrementing clientId
            var allClients = await _clientRepository.GetAll();
            if (allClients is null) throw new ArgumentException();
            var allId = (allClients.Select(elem => elem.clientId)).ToList();
            var max = 1;
            if (allId.Count > 0) max = allId.Max() + 1;
            #endregion

            Client newClient = new()
            {
                Name = clientDto.Name,
                Street = clientDto.Street,
                PhoneNumber = clientDto.PhoneNumber,
                Email = clientDto.Email,
                Password = clientDto.Password,
                NIF = clientDto.NIF,
                Type = clientDto.Type,
                PostalCode = clientDto.PostalCode,
                Zone = clientDto.ZoneId,
                clientId = max
            };

            var result = await _clientRepository.Add(newClient);
            if (result is null) throw new ArgumentException();

            return new OryonContentResponse<ClientResponse>().SetSuccess(Utils.toDto(result), 1);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ClientResponse>().SetFail(ex);
        }

    }

    public async Task<OryonContentResponse<ClientResponse>> DeleteClient(Guid id)
    {
        try
        {
            var client = await _clientRepository.Get(id);
            if (client is null) throw new ArgumentException();

            await _clientRepository.Delete(id);
            var result = await _clientRepository.Get(id);

            if (result != null) throw new ArgumentException();
            return new OryonContentResponse<ClientResponse>().SetSuccess();
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ClientResponse>().SetFail(ex);
        }

    }

    public async Task<OryonContentResponse<List<ClientResponse>>> GetAllClients()
    {
        try
        {
            var result = await _clientRepository.GetAll();
            if (result is null) throw new ArgumentException();

            return new OryonContentResponse<List<ClientResponse>>().SetSuccess(Utils.toDto(result), result.Count);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<List<ClientResponse>>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<ClientResponse>> GetClient(Guid id)
    {
        try
        {
            var result = await _clientRepository.Get(id);
            if (result is null) throw new ArgumentException();

            return new OryonContentResponse<ClientResponse>().SetSuccess(Utils.toDto(result), 1);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ClientResponse>().SetFail(ex);
        }


    }

    public async Task<OryonContentResponse<ClientResponse>> UpdateClient(Guid id, CreateClientDto clientDto)
    {
        try
        {
            var isValid = ServicesRestrictions.validClient(clientDto.Type!);
            if(!isValid) throw new ArgumentException();

            
            var client = await _clientRepository.Get(id);
            if (client is null) throw new ArgumentException("Client not Found with that specific id");

            #region Validating Zone
            var zone = await _zoneRepository.Get(clientDto.ZoneId);
            if (zone is null) throw new ArgumentException();
            #endregion

            // Update Client
            client.Name = clientDto.Name;
            client.Street = clientDto.Street;
            client.PhoneNumber = clientDto.PhoneNumber;
            client.Email = clientDto.Email;
            client.Password = clientDto.Password;
            client.NIF = clientDto.NIF;
            client.Type = clientDto.Type;
            client.PostalCode = clientDto.PostalCode;
            client.Zone = clientDto.ZoneId;
            client.Changed = DateTime.Now;

            await _clientRepository.Update(client);

            var result = await _clientRepository.Get(id);
            if (result is null) throw new ArgumentException();

            return new OryonContentResponse<ClientResponse>().SetSuccess(Utils.toDto(result), 1);

        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ClientResponse>().SetFail(ex);
        }
    }
}