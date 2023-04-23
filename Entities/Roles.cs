namespace Catalog.Entities;

public class Role : Entity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<string> Permissions { get; set; } = new();
    public bool IsActive { get; set; } = true;
}