using Catalog.Dtos;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Interfaces.ServiceInterfaces;

public interface IProductServices
{
    Task<OryonContentResponse<List<ProductResponse>>> GetAllProducts();
    Task<OryonContentResponse<ProductResponse>> GetProduct(Guid id);
    Task<OryonContentResponse<ProductResponse>> CreateProduct(CreateProductDto productDto);
    Task<OryonContentResponse<ProductResponse>> UpdateProduct(Guid id, CreateProductDto productDto);
    Task<OryonContentResponse<ProductResponse>> DeleteProduct(Guid id);
}