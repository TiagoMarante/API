using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos;

public class CreateClientDto
{
   

    [Required]
    public string? Name { get; }
    
    [Required]
    public string? Street { get; }

    [Required]
    public string? PhoneNumber { get; }
    
    [Required]
    [EmailAddress]
    public string? Email { get; }

    [Required]
    public string? PostalCode { get; }
    
    [Required]
    [PasswordPropertyText]
    public string? Password { get; }

    [Required]
    public Guid ZoneId { get; set;}
    
    [Required]
    public string? NIF { get; }

    [Required]
    public string? Type { get; }

    public CreateClientDto(string? name, string? street, string? phoneNumber, string? email, string? postalCode, string? password, string? nIF, string? type)
    {
        Name = name;
        Street = street;
        PhoneNumber = phoneNumber;
        Email = email;
        PostalCode = postalCode;
        Password = password;
        NIF = nIF;
        Type = type;
    }
}