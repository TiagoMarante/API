using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Interfaces.ServiceInterfaces;

namespace Catalog.Services;

public class OrdersService : IOrderServices
{

    private readonly IOrdersRepository _ordersRepository;
    private readonly IProductRepository _productRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IZonesRepository _zoneRepository;

    public OrdersService(IOrdersRepository ordersRepository, IProductRepository productRepository,
    IClientRepository clientRepository, IZonesRepository zoneRepository)
    {
        _ordersRepository = ordersRepository;
        _productRepository = productRepository;
        _clientRepository = clientRepository;
        _zoneRepository = zoneRepository;
    }

    public async Task<OryonContentResponse<OrderResponse>> CreateOrder(CreateOrderDto orderDto)
    {
        try
        {
            //validate if Client exist
            var isClientValid = await _clientRepository.Get(orderDto.ClientId);
            if (isClientValid is null) throw new ArgumentException();
            if (orderDto.TypeOfOrder is null) throw new ArgumentException();

            //validate if Zone exist
            var zone = await _zoneRepository.Get(isClientValid.Zone);
            if (zone is null) throw new ArgumentException();

            //validate Restrictions
            var isValid = ServicesRestrictions.validOrder(orderDto.TypeOfOrder!);
            if (!isValid) throw new ArgumentException();
            if (orderDto.ProductWithQuantity is null) throw new ArgumentException();

            var productsQuant = new List<ProductOrder>();

            foreach (var elem in orderDto.ProductWithQuantity)
            {
                var product = await _productRepository.Get(elem.ProductGuid);
                if (product is null) throw new ArgumentException();

                productsQuant.Add(new ProductOrder(product, elem.Quantity));
            }

            Order newOrder = new()
            {
                clientId = orderDto.ClientId,
                TimeToDelivery = orderDto.TimeToDelivery,
                TypeOfOrder = orderDto.TypeOfOrder,
                Observations = orderDto.Observations,
                ProductWithQuantity = productsQuant,
            };


            float TotalPrice = 0;
            // Calcule Product Price
            foreach (var elem in productsQuant)
            {
                TotalPrice += (elem.product.Price * elem.quantity);
            }

            // Add the tax of delivery to totalPrice
            if (orderDto.TypeOfOrder.Equals("ENTREGA"))
            {
                TotalPrice += zone.Price;
            }

            newOrder.TotalPrice = TotalPrice;

            var result = await _ordersRepository.Add(newOrder);
            if (result == null) throw new ArgumentException();

            return new OryonContentResponse<OrderResponse>().SetSuccess(Utils.toDto(result), 1);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<OrderResponse>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<OrderResponse>> DeactivateOrder(Guid id)
    {
        try
        {
            //validate if Client exist
            var isOrderValid = await _ordersRepository.Get(id);
            if (isOrderValid is null) throw new ArgumentException();

            //update flag to false
            isOrderValid.Active = false;
            await _ordersRepository.Update(isOrderValid);

            var result = await _ordersRepository.Get(id);
            if (result is null) throw new ArgumentException();


            return new OryonContentResponse<OrderResponse>().SetSuccess(Utils.toDto(result), 1);

        }
        catch (Exception ex)
        {
            return new OryonContentResponse<OrderResponse>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<List<OrderResponse>>> GetAllOrders()
    {
        try
        {
            var result = await _ordersRepository.GetAll();
            return new OryonContentResponse<List<OrderResponse>>().SetSuccess(Utils.toDto(result), result.Count);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<List<OrderResponse>>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<List<OrderResponse>>> GetOrdersByClientId(Guid clientId)
    {
        try
        {
            List<Order> clientOrders = new List<Order>();
            var result = await _ordersRepository.GetAll();

            foreach (var elem in result)
            {
                if (elem.clientId == clientId)
                {
                    clientOrders.Add(elem);
                }
            }

            return new OryonContentResponse<List<OrderResponse>>().SetSuccess(Utils.toDto(clientOrders), clientOrders.Count);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<List<OrderResponse>>().SetFail(ex);
        }
    }

    public async Task<OryonContentResponse<List<OrderResponse>>> OrdersByFlag(bool flag)
    {
        try
        {
            List<Order> orderFlag = new List<Order>();
            var result = await _ordersRepository.GetAll();

            if(flag){
                foreach (var elem in result)
                {
                    if (elem.Active == flag)
                    {
                        orderFlag.Add(elem);
                    }
                }
            }else{
                foreach (var elem in result)
                {
                    if (elem.Active == flag)
                    {
                        orderFlag.Add(elem);
                    }
                }
            }

            return new OryonContentResponse<List<OrderResponse>>().SetSuccess(Utils.toDto(orderFlag), orderFlag.Count);
        }
        catch (Exception ex)
        {
            return new OryonContentResponse<List<OrderResponse>>().SetFail(ex);
        }
    }



    /* Dont need in this iteration
    
    public Task<HephaestusResponse<Order>> DeleteOrder(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<HephaestusResponse<List<Order>>> GetAllOrders()
    {
        try
        {
            var result = await _ordersRepository.GetAll();   
            return new HephaestusResponse<List<Order>>(result, true);
        }
        catch (System.Exception)
        {
             return new HephaestusResponse<List<Order>>(null, false);
        }
    }

    public async Task<HephaestusResponse<Order>> GetOrder(Guid id)
    {
        try
        {
            var result = await _ordersRepository.Get(id);   
            return new HephaestusResponse<Order>(result, true);
        }
        catch (System.Exception)
        {
             return new HephaestusResponse<Order>(null, false);
        }
    }
    */


}