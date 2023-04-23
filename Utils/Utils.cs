using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog;

public class Utils
{
    #region Client Response
    public static ClientResponse toDto(Client data)
    {
        return new ClientResponse()
        {
            Id = data.Id.ToString(),
            Name = data.Name,
            Street = data.Street,
            PhoneNumber = data.PhoneNumber,
            Email = data.Email,
            NIF = data.NIF,
            Type = data.Type,
            Zone = data.Zone.ToString(),
            PostalCode = data.PostalCode,
            clientId = data.clientId
        };
    }

    public static List<ClientResponse> toDto(List<Client> data)
    {
        return (data.Select(elem => toDto(elem))).ToList();
    }

    #endregion

    #region  Order Response
    public static OrderResponse toDto(Order data)
    {
        return new OrderResponse()
        {
            Id = data.Id.ToString(),
            TimeToDelivery = data.TimeToDelivery,
            TypeOfOrder = data.TypeOfOrder,
            Observations = data.Observations,
            ProductWithQuantity = data.ProductWithQuantity,
            TotalPrice = data.TotalPrice,
            ClientId = data.clientId.ToString(),
            Active = data.Active
        };
    }

    public static List<OrderResponse> toDto(List<Order> data)
    {
        return (data.Select(elem => toDto(elem))).ToList();
    }

    #endregion

    #region  Product Response
    public static ProductResponse toDto(Product data)
    {
        return new ProductResponse()
        {
            Id = data.Id.ToString(),
            Name = data.Name,
            Description = data.Description,
            Price = data.Price,
            TypeOfProduct = data.TypeOfProduct
        };
    }

    public static List<ProductResponse> toDto(List<Product> data)
    {
        return (data.Select(elem => toDto(elem))).ToList();
    }

    #endregion

    #region  Zone Response
    public static ZoneResponse toDto(Zone data)
    {
        return new ZoneResponse()
        {
            Id = data.Id.ToString(),
            Local = data.Local,
            Price = data.Price
        };
    }

    public static List<ZoneResponse> toDto(List<Zone> data)
    {
        return (data.Select(elem => toDto(elem))).ToList();
    }

    #endregion
}