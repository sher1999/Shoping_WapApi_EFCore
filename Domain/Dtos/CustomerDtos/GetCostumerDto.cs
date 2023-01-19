using System.ComponentModel.DataAnnotations;
namespace Domain.Dtos.CompanyDtos;

public class GetCostumerDto
{
    public int Id {get;set;}
  public string? FirstName{get;set;}
  public string? LastName{get;set;}
  public string? Address{get;set;}
  public string? Phone{get;set;}
  public string? Email{get;set;}
    public GetCostumerDto()
    {
        
    }
   public GetCostumerDto(int id,string? firstName,string? lastName,string? address,string? phone,string? email )
  {
    Id=id;
    FirstName=firstName;
    LastName=lastName;
    Address=address;
    Phone=phone;
    Email=email;
  }

}
