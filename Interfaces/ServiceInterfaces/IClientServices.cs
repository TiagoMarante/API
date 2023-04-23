using Catalog.Dtos;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Interfaces.ServiceInterfaces;

public interface IClientServices
{
    Task<OryonContentResponse<List<ClientResponse>>> GetAllClients();
    Task<OryonContentResponse<ClientResponse>> GetClient(Guid id);
    Task<OryonContentResponse<ClientResponse>> CreateClient(CreateClientDto clientDto);
    Task<OryonContentResponse<ClientResponse>> UpdateClient(Guid id, CreateClientDto clientDto);
    Task<OryonContentResponse<ClientResponse>> DeleteClient(Guid id);
}