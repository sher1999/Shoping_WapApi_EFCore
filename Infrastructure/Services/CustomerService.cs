using Domain.Entities;
using Domain.Dtos.CompanyDtos;
using Domain.Dtos.CustomerDtos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore; 
namespace Infrastructure.Services;


public class CustomerService:GenericCrud<Customerr>
{
    private readonly DataContext _context;
public CustomerService(DataContext context ):base(context)
{
    _context = context;
}

    public List<GetCostumerDto> GetCustomers()
    {
        return _context.Customerrs.Select(x=>new GetCostumerDto(x.Id,x.FirstName,x.LastName,x.Address,x.Phone,x.Email)).ToList();
    }
    public List<GetCostumerDto> GetCustomersById(int c)
    {  return  _context.Customerrs.
       
      Select(x=>new GetCostumerDto(x.Id,x.FirstName,x.LastName,x.Address,x.Phone,x.Email)).ToList();
    }
 public void AddCostumerDto(AddCostumerDto c)
    {
        var mapped = new Customerr(c.Id, c.FirstName,c.LastName,c.Address,c.Phone,c.Email );
        _context.Customerrs.Add(mapped);
        _context.SaveChanges();
    }

 public bool  DeleteCustumerById(int id)
    {
        var entity= _context.Customerrs.Find(id);
         _context.Remove(entity);
         _context.SaveChanges();
        return true;
      
    }

    
 public void UpdateCostumerDto(GetCostumerDto c)
    { var entity= _context.Customerrs.Find(c.Id);
    entity.FirstName=c.FirstName;
    entity.LastName=c.LastName;
    entity.Address=c.Address;
    entity.Phone=c.Phone;
    entity.Email=c.Email;
        _context.Customerrs.Update(entity);
        _context.SaveChanges();
    }
 public List<GetCostumerDto> GetCompanyByName(string name)
    {
        return _context.Customerrs.
            Where(x => x.FirstName.ToLower().Contains(name.ToLower())).
            Select(x => new GetCostumerDto(x.Id,x.FirstName,x.LastName,x.Address,x.Phone,x.Email)).ToList();
    }

}
