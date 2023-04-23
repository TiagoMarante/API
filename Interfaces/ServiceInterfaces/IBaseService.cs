using Catalog.Dtos;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Interfaces.ServiceInterfaces;

public interface IBaseService<T>
{
    Task<OryonContentResponse<List<T>>> GetAll();
    Task<OryonContentResponse<T>> GetById(Guid id);
    Task<OryonContentResponse<T>> Add(dynamic dto);
    Task<OryonContentResponse<T>> Update(Guid id, dynamic dto);
    Task<OryonContentResponse<T>> Delete(Guid id);
}