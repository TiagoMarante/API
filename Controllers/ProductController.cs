using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;


[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IProductServices _productServices;

    public ProductController(IProductServices productServices)
    {
        _productServices = productServices;
    }



    [HttpGet]
    public async Task<ActionResult<OryonContentResponse<List<ProductResponse>>>> GetAllProducts()
    {
        var result = await _productServices.GetAllProducts();
        return result.Data is null ? NotFound() : Ok(result);
    }


    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OryonContentResponse<ProductResponse>>> GetProduct(Guid id)
    {
        var result = await _productServices.GetProduct(id);
        return result.Data is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<OryonContentResponse<ProductResponse>>> CreateProduct(CreateProductDto productDto)
    {
        var result = await _productServices.CreateProduct(productDto);
        return result.Data is null ? StatusCode(500) : Ok(result);
    }



    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateZone(Guid id, CreateProductDto productDto)
    {
        var result = await _productServices.UpdateProduct(id, productDto);
        return result.Success is false ?  NotFound("Id not Found") : Ok(result.Success);
    }


    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteZone(Guid id)
    {
        var result = await _productServices.DeleteProduct(id);
        return result.Success is false ? NotFound("Id not Found") : Ok(result.Success);
    }
}