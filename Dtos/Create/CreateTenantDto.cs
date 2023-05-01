using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos.Create;

public class CreateTenantDto
{
    [Required] public string TenantName { get; set; }

    [Required] public string TenantDescription { get; set; }

    [Url] public string Website { get; set; }

    [Url] public string LogoUrl { get; set; }

    public CreateTenantDto(string tenantName, string tenantDescription, string website, string logoUrl)
    {
        TenantName = tenantName;
        TenantDescription = tenantDescription;
        Website = website;
        LogoUrl = logoUrl;
    }
}