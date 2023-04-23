namespace Catalog.Entities;


public class Order : Entity{
    public Guid clientId { get; set; }
    public DateTime TimeToDelivery { get; set; }
    public string? TypeOfOrder { get; set; }
    public string? Observations { get; set; }
    public List<ProductOrder>? ProductWithQuantity { get; set; }
    public float TotalPrice { get; set; }
    public bool Active { get; set; } = true;
}