using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos;

public class AddClientZoneDto
{

    [Required]
    public Guid ClientId { get; set;}
    
    [Required]
    public Guid ZoneId { get; set;}
    
}