using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos;

public class CreateProductDto
{

    [Required]
    public string? ProductName { get; }

    [Required]
    public string? Description { get; }
    
    [Required]
    public float Price { get; }

    [Required]
    public string? TypeOfProduct { get; }

    public CreateProductDto(string? productName, string? description, float price, string? typeOfProduct)
    {
        ProductName = productName;
        Description = description;
        Price = price;
        TypeOfProduct = typeOfProduct;
    }
}