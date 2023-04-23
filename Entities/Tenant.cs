namespace Catalog.Entities;

public class Tenant : Entity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<User> Users { get; set; } = new();
    public List<Role> Roles { get; set; } = new();
    public string Industry { get; set; } = null!;
    public string Website { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public string BillingAddress { get; set; } = null!;
    public string PaymentMethod { get; set; } = null!;
    public DateTime SubscriptionStartDate { get; set; }
    public DateTime SubscriptionEndDate { get; set; }
    public string SubscriptionStatus { get; set; } = null!;
    public string SupportContact { get; set; } = null!;
}