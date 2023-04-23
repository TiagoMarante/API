using Catalog.Entities;

namespace Catalog.Dtos;

public class ProductResponse
{
    public string? Id { get; set;}
    public string? Name { get; set;}
    public string? Description { get; set; }
    public float Price { get; set; }
    public string? TypeOfProduct { get; set; }
}