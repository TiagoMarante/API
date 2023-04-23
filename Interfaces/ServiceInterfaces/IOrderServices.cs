using Catalog.Dtos;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Interfaces.ServiceInterfaces;

public interface IOrderServices
{
    Task<OryonContentResponse<List<OrderResponse>>> GetAllOrders();
    Task<OryonContentResponse<List<OrderResponse>>> GetOrdersByClientId(Guid clientId);
    Task<OryonContentResponse<OrderResponse>> CreateOrder(CreateOrderDto orderDto);
    Task<OryonContentResponse<OrderResponse>> DeactivateOrder(Guid id);
    Task<OryonContentResponse<List<OrderResponse>>> OrdersByFlag(bool flag);
    //Task<HephaestusResponse<Order>> Update(Guid id, CreateOrderDto orderDto);
    //Task<HephaestusResponse<Order>> DeleteOrder(Guid id);
}