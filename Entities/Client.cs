using Catalog.Dtos;
using System.Linq;

namespace Catalog.Entities;

public class Client : Entity
{
    public string? Name { get; set; }

    public string? Street { get; set; }

    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? NIF { get; set; }

    public string? Type { get; set; }

    public Guid Zone { get; set; }

    public string? PostalCode { get; set; }

    public int clientId { get; set; }
}