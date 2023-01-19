using Domain.Entities;
using Domain.Dtos.OrderDetailDtos;
using Infrastructure.Data;
using Domain.Dtos.OrderDtos;
using Domain.Dtos.CompanyDtos;
using Domain.Dtos.CustomerDtos;
using Domain.Dtos.ProductDtos;

using Microsoft.EntityFrameworkCore; 
namespace Infrastructure.Services;


public class OrderService:GenericCrud<Customerr>
{
    private readonly DataContext _context;
public OrderService(DataContext context ):base(context)
{
    _context = context;
}

    public List<GetOrderDto> GetOrder()
    {
        return _context.Orders.Select(x=>new GetOrderDto(x.Id,x.CustomerrId)).ToList();
    }
    public List<GetOrderDto> GetOrderById(int c)
    {  return  _context.Orders.
       
      Select(x=>new GetOrderDto(x.Id,x.CustomerrId)).ToList();
    }
 public void AddOrderDto(AddOrderDto c)
    {
        var mapped = new Order(c.Id, c.CustumerId);
        _context.Orders.Add(mapped);
        _context.SaveChanges();
    }

 public bool  DeleteOrderById(int id)
    {
        var entity= _context.Orders.Find(id);
         _context.Remove(entity);
         _context.SaveChanges();
        return true;
      
    }
    
 public void UpdateOrderrDto(AddOrderDto c)
    { var entity= _context.Orders.Find(c.Id);
    entity.CustomerrId=c.CustumerId;
   
        _context.Orders.Update(entity);
        _context.SaveChanges();
    }

public List<OrderDto> GetOrders()
    {
        return _context.Orders.Include(x=>x.Customerr).Select(x => new OrderDto()
        {
             Address = x.Customerr.Address,
            Id = x.Id,
            Phone=x.Customerr.Phone,
            Email=x.Customerr.Email,
            OrderPlaced = x.OrderPlaced,
            OrderPFulfilled=x.OrderPFulfilled,
            CustomerId = x.CustomerrId,
            FullName = string.Concat(x.Customerr.FirstName, " ", x.Customerr.LastName)       
        }).ToList();
    }
    
    public List<OrderDto> GetOrdersByDate(DateTime date)
    {
        
        return _context.Orders
            .Where(x=>x.OrderPlaced.Date == date.Date)
            .Select(x => new OrderDto()
        {
          
           Address = x.Customerr.Address,
            Id = x.Id,
            Phone=x.Customerr.Phone,
            Email=x.Customerr.Email,
            OrderPlaced = x.OrderPlaced,
            OrderPFulfilled=x.OrderPFulfilled,
            CustomerId = x.CustomerrId,
            FullName = string.Concat(x.Customerr.FirstName, " ", x.Customerr.LastName)  
        }).ToList();
    }

}
