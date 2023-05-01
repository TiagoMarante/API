namespace Catalog.Dtos.Response.Tenant;

public class TenantResponse
{
    public string? Id { get; set; }

    public string? TenantName { get; set; }

    public string? TenantDescription { get; set; }

    public string? Website { get; set; }

    public string? LogoUrl { get; set; }

    public string BillingAddress { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public DateTime SubscriptionStartDate { get; set; }

    public DateTime SubscriptionEndDate { get; set; }

    public string SubscriptionStatus { get; set; } = null!;

    public string SupportContact { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Changed { get; set; }
}