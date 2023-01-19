namespace Domain.Dtos.OrderDtos;

public class OrderDto
{
      public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime OrderPFulfilled{get;set;}
    public string? FullName { get; set; }
    public string? Address { get; set; }
    public string? Phone{get;set;}
    public string? Email{get;set;}



}
