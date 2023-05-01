namespace Catalog.Settings;

public class MongoDbSettings {

    public string ConnectionString  { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string ItemsCollectionName { get; set; } = null!;
    public string UsersCollectionName { get; set; } = null!;
    public string ClientsCollectionName { get; set; } = null!;
    public string ZonesCollectionName { get; set; } = null!;
    public string TenantsCollectionName { get; set; } = null!;
    public string ProductsCollectionName { get; set; } = null!;
    public string OrdersCollectionName { get; set; } = null!;

}