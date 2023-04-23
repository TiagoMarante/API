using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos;

public class CreateZoneDto
{

    [Required]
    public string? Local { get; }
    
    [Required]
    public float Price { get; }

    public CreateZoneDto(string? local, float price)
    {
        Local = local;
        Price = price;
    }
}