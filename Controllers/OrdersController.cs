using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;


[ApiController]
[Route("order")]
public class OrdersController : ControllerBase
{
    private readonly IOrderServices _orderServices;

    public OrdersController(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }

    [HttpPost]
    public async Task<ActionResult<OryonContentResponse<OrderResponse>>> CreateOrder(CreateOrderDto orderDto)
    {
        var result = await _orderServices.CreateOrder(orderDto);
        return result.Data is null ? StatusCode(500) : Ok(result);
    }



    [HttpGet("/order/client/{id:guid}")]
    public async Task<ActionResult<OryonContentResponse<List<OrderResponse>>>> GetOrdersByClient(Guid id)
    {
        var result = await _orderServices.GetOrdersByClientId(id);
        return result.Data is null ? NotFound() : Ok(result);
    }


    [HttpGet]
    public async Task<ActionResult<List<OrderResponse>>> GetOrders()
    {
        var result = await _orderServices.GetAllOrders();
        return result.Data is null ? NotFound() : Ok(result);
    }

    [HttpPost("deactivate/{id:guid}")]
    public async Task<ActionResult<OryonContentResponse<OrderResponse>>> DeactivateOrder(Guid id)
    {
        var result = await _orderServices.DeactivateOrder(id);
        return result.Data is null ? StatusCode(500) : Ok(result);
    }

    [HttpGet("deactivate")]
    public async Task<ActionResult<OryonContentResponse<OrderResponse>>> DeactivateOrders()
    {
        var result = await _orderServices.OrdersByFlag(false);
        return result.Data is null ? StatusCode(500) : Ok(result);
    }

    [HttpGet("active")]
    public async Task<ActionResult<OryonContentResponse<OrderResponse>>> ActivateOrder()
    {
        var result = await _orderServices.OrdersByFlag(true);
        return result.Data is null ? StatusCode(500) : Ok(result);
    }

}