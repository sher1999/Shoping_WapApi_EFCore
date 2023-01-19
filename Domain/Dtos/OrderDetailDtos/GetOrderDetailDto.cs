namespace Domain.Dtos.OrderDetailDtos;

public class GetOrderDetailDto
{
    public int Id {get;set;}
    public int Quantity {get;set;}
    public int OrderId {get;set;}
    public int ProductId {get;set;}
    public GetOrderDetailDto()
    {
        
    }
    public GetOrderDetailDto(int id,int quantity,int orderId,int productId)
    {
       Id=id;
       Quantity=quantity;
       OrderId=orderId;
       ProductId=productId; 
    }
}
