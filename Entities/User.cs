namespace Catalog.Entities;

public class User : Entity
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<Role> Roles { get; set; } = new();
    public bool IsActive { get; set; } = true;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string JobTitle { get; set; } = null!;
    public string Department { get; set; } = null!;
    public string ManagerId { get; set; } = null!;
    public DateTime LastLogin { get; set; } = DateTime.Now;
    public bool IsLockedOut { get; set; } = false;
    public int FailedLoginAttempts { get; set; } = 0;
}