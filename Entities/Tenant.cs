using Catalog.Dtos.Create;
using Catalog.Dtos.Response.Tenant;

namespace Catalog.Entities;

public class Tenant : Entity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<User> Users { get; set; } = new();
    public List<Role> Roles { get; set; } = new();

    public Tenant(CreateTenantDto dto)
    {
        Name = dto.TenantName;
        Description = dto.TenantDescription;
    }

    public TenantResponse ToDto()
    {
        return new TenantResponse()
        {
            Id = Id.ToString(),
            TenantName = Name,
            TenantDescription = Description,
            Created = Created,
            Changed = Changed
        };
    }
}