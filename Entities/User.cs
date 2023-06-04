namespace Catalog.Entities;

public class User : Entity
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<Role> Roles { get; set; } = new();
    public DateTime LastLogin { get; set; } = DateTime.Now;

}