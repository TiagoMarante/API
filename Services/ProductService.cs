using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Interfaces.ServiceInterfaces;

namespace Catalog.Services;

public class ProductService : IProductServices
{

    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<OryonContentResponse<ProductResponse>> CreateProduct(CreateProductDto productDto)
    {
        try
        {
            var isValid = ServicesRestrictions.validProduct(productDto.TypeOfProduct!);
            if(!isValid) throw new ArgumentException();


            Product newProduct = new()
            {
                Name = productDto.ProductName,
                Description = productDto.Description,
                Price = productDto.Price,
                TypeOfProduct = productDto.TypeOfProduct
            };

            var result = await _productRepository.Add(newProduct);
            if(result == null) throw new ArgumentException();

            return new OryonContentResponse<ProductResponse>().SetSuccess(Utils.toDto(result), 1);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ProductResponse>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<ProductResponse>> DeleteProduct(Guid id)
    {
        try
        {
            var product = await _productRepository.Get(id);
            if (product is null) throw new ArgumentException();

            await _productRepository.Delete(id);
            var result = await _productRepository.Get(id);

            if(result != null) throw new ArgumentException();

            return new OryonContentResponse<ProductResponse>().SetSuccess();

        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ProductResponse>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<List<ProductResponse>>> GetAllProducts()
    {
        try
        {
            var result = await _productRepository.GetAll();
            return new OryonContentResponse<List<ProductResponse>>().SetSuccess(Utils.toDto(result), result.Count);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<List<ProductResponse>>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<ProductResponse>> GetProduct(Guid id)
    {
        try
        {
            var result = await _productRepository.Get(id);
            if (result is null) throw new ArgumentException();

            return new OryonContentResponse<ProductResponse>().SetSuccess(Utils.toDto(result), 1);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ProductResponse>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<ProductResponse>> UpdateProduct(Guid id, CreateProductDto productDto)
    {
        try
        {
            var isValid = ServicesRestrictions.validProduct(productDto.TypeOfProduct!);
            if(!isValid) throw new ArgumentException();


            var product = await _productRepository.Get(id);
            if (product is null) throw new ArgumentException();
            
            //Update Product
            product.Name = productDto.ProductName;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.TypeOfProduct = productDto.TypeOfProduct;
            product.Changed = DateTime.Now;

            await _productRepository.Update(product);
            var result = await _productRepository.Get(id);

            if(result is null) throw new ArgumentException();

            return new OryonContentResponse<ProductResponse>().SetSuccess(Utils.toDto(result), 1);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<ProductResponse>().SetFail(ex);
        }
    }
}