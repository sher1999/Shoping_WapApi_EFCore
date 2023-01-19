namespace Domain.Dtos.OrderDetailDtos;

public class GetOrderDto
{
    public int Id {get;set;}
    public DateTime OrderPlaced{get;set;}
    public DateTime OrderPFulfilled{get;set;}
    public int CustumerId {get;set;}
    public GetOrderDto()
    {
        
    }
     public GetOrderDto(int id,  int custumerId)
    {
        Id = id;
         OrderPlaced=DateTime.UtcNow;
       OrderPFulfilled=DateTime.UtcNow;
        CustumerId = custumerId;
    }
}
