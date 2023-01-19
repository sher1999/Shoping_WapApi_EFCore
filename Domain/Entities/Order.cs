using Domain.Entities;
namespace Domain.Entities;

public class Order
{
    public int Id {get;set;}
    public DateTime OrderPlaced{get;set;}
    public DateTime OrderPFulfilled{get;set;}
    public int CustomerrId {get;set;}
    public Customerr? Customerr{get;set;}

    public OrderDetail? OrderDetail {get;set;}
 
    public Order()
    {
        
    }

    public Order(int id,  int customerrId)
    {
        Id = id;
       OrderPlaced=DateTime.UtcNow;
       OrderPFulfilled=DateTime.UtcNow;
        CustomerrId = customerrId;
    }
}
