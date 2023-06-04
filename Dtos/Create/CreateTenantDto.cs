using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos.Create;

public class CreateTenantDto
{
    [Required] public string TenantName { get; set; }

    [Required] public string TenantDescription { get; set; }


    public CreateTenantDto(string tenantName, string tenantDescription)
    {
        TenantName = tenantName;
        TenantDescription = tenantDescription;
    }
}