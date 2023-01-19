namespace Domain.Dtos.ProductDtos;

public class GetProductDto
{
    public int Id {get;set;}
    public string? Name{get;set;}
    public decimal Price{get;set;}

    public GetProductDto()
    {
        
    }
     public GetProductDto(int id,string? name,decimal price)
    {
        Id=id;
        Name=name;
        Price=price;
    }
}
