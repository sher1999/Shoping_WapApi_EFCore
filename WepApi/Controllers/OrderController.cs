using Domain.Entities;
using Domain.Dtos.OrderDetailDtos;
using Domain.Dtos.OrderDtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController:ControllerBase
{
   private readonly OrderService _orderService;

   public OrderController(OrderService orderService)
   {
    _orderService=orderService;
   }
 [HttpGet("Get")]
        public List<GetOrderDto> GetCostumers()
        {
                return _orderService.GetOrder();
        }
 [HttpGet("GetById")]
        public List<GetOrderDto> GetCostumersById(int c)
        {
                return _orderService.GetOrderById(c);
        }
[HttpPost("Add")]
        public bool AddCustomer(AddOrderDto c)
        {
                _orderService.AddOrderDto(c);
                return true;
        }
 [HttpDelete("{id}")]
    public void Delete(int id) => _orderService.DeleteOrderById(id);

    [HttpPut("Update")]
    public void UpdateCostumerDto([FromBody] AddOrderDto c) => _orderService.UpdateOrderrDto(c);

     [HttpGet("GetAllDatas")]
    public List<OrderDto> GetOrders()
    {
        return _orderService.GetOrders();
    }
    
    
    [HttpGet("GetOrdersByDate")]
    public List<OrderDto> GetOrdersByDate(DateTime date)
    {
        return _orderService.GetOrdersByDate(date);
    }
}