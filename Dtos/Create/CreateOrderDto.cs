using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos;

public class CreateOrderDto
{

    [Required]
    public Guid ClientId { get; }

    [Required]
    public DateTime TimeToDelivery { get; }

    [Required]
    public string? TypeOfOrder { get; }

    [Required]
    public string? Observations { get; }

    [Required]
    public List<ProductOrderDto> ProductWithQuantity {get; }

    public CreateOrderDto(Guid clientId, DateTime timeToDelivery, string? typeOfOrder, string? observations, List<ProductOrderDto> productWithQuantity)
    {
        ClientId = clientId;
        TimeToDelivery = timeToDelivery;
        TypeOfOrder = typeOfOrder;
        Observations = observations;
        ProductWithQuantity = productWithQuantity;
    }
}