using Domain.Entities;
using Domain.Dtos.OrderDetailDtos;
using Domain.Dtos.OrderDtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderDetailController:ControllerBase
{
       private readonly OrderDetailService _orderDetailService;
       public OrderDetailController(OrderDetailService orderDetailService )
       {
          _orderDetailService=orderDetailService;
       }

        [HttpGet("Get")]
        public List<GetOrderDetailDto> GetOrderDetails()
        {
                return _orderDetailService.GetOrderDetail();
        }

        [HttpPost("Add")]
        public bool AddOrderDto(AddOrderDetailDto c)
        {
                _orderDetailService.AddOrderDto(c);
                return true;
        }
}
