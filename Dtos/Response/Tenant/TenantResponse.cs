namespace Catalog.Dtos.Response.Tenant;

public class TenantResponse
{
    public string? Id { get; set; }

    public string? TenantName { get; set; }

    public string? TenantDescription { get; set; }

    public DateTime Created { get; set; }

    public DateTime Changed { get; set; }
}