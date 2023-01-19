using Domain.Entities;
using Domain.Dtos.OrderDetailDtos;
using Domain.Dtos.OrderDetailDtos;
using Infrastructure.Data;
using Domain.Dtos.OrderDtos;
using Domain.Dtos.CompanyDtos;
using Domain.Dtos.CustomerDtos;
using Domain.Dtos.ProductDtos;

using Microsoft.EntityFrameworkCore; 

namespace Infrastructure.Services;

public class OrderDetailService:GenericCrud<OrderDetail>
{
 private readonly DataContext _context;
public OrderDetailService(DataContext context ):base(context)
{
    _context = context;
}
 public List<GetOrderDetailDto> GetOrderDetail()
    {
        return _context.OrderDetails.Select(x=>new GetOrderDetailDto(x.Id,x.Quantity,x.OrderId,x.ProductId)).ToList();
    }
 public void AddOrderDto(AddOrderDetailDto c)
    {
        var mapped = new OrderDetail(c.Id, c.Quantity,c.OrderId,c.ProductId);
        _context.OrderDetails.Add(mapped);
        _context.SaveChanges();
    }

}
