using Catalog.Dtos.Create;
using Catalog.Dtos.Response.Tenant;

namespace Catalog.Entities;

public class Tenant : Entity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<User> Users { get; set; } = new();
    public List<Role> Roles { get; set; } = new();
    public string? Industry { get; set; }
    public string? Website { get; set; }
    public string? LogoUrl { get; set; }
    public string? BillingAddress { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime SubscriptionStartDate { get; set; }
    public DateTime SubscriptionEndDate { get; set; }
    public string? SubscriptionStatus { get; set; }
    public string? SupportContact { get; set; }

    public Tenant(CreateTenantDto dto)
    {
        Name = dto.TenantName;
        Description = dto.TenantDescription;
        Website = dto.Website;
        LogoUrl = dto.LogoUrl;
    }

    public TenantResponse ToDto()
    {
        return new TenantResponse()
        {
            Id = Id.ToString(),
            TenantName = Name,
            TenantDescription = Description,
            Website = Website,
            LogoUrl = LogoUrl,
            Created = Created,
            Changed = Changed
        };
    }
}