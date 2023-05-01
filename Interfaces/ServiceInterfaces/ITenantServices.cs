using Catalog.Dtos;
using Catalog.Dtos.Response.Tenant;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Interfaces.ServiceInterfaces;

public interface ITenantServices : IBaseService<TenantResponse>
{
}