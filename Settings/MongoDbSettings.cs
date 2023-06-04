﻿namespace Catalog.Settings;

public class MongoDbSettings {

    public string ConnectionString  { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string TenantsCollectionName { get; set; } = null!;
}