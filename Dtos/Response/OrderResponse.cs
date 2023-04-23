using Catalog.Entities;

namespace Catalog.Dtos;

public class OrderResponse
{
    public string? Id { get; set;}

    public string? ClientId { get; set;}
    public DateTime TimeToDelivery { get; set;}
    public string? TypeOfOrder { get; set;}
    public string? Observations { get; set;}
    public List<ProductOrder>? ProductWithQuantity { get; set; }
    public float TotalPrice { get; set; }
    public bool Active { get; set; }
}