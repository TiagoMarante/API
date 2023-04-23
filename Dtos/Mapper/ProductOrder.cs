namespace Catalog.Entities;


public class ProductOrder{
    public Product product { get; set; }
    public float quantity { get; set; }

    public ProductOrder(Product product, float quantity)
    {
        this.product = product;
        this.quantity = quantity;
    }
}