using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos;

public class ProductOrderDto{
    
    [Required]
    public Guid ProductGuid { get; }

    [Required]
    public float Quantity { get; }

    public ProductOrderDto(Guid productGuid, float quantity)
    {
        ProductGuid = productGuid;
        Quantity = quantity;
    }
}