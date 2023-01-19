using Domain.Entities;
using Domain.Dtos.ProductDtos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore; 
namespace Infrastructure.Services;


public class ProductService:GenericCrud<Customerr>
{
    private readonly DataContext _context;
public ProductService(DataContext context ):base(context)
{
    _context = context;
}

    public List<GetProductDto> GetPr()
    {
        return _context.Products.Select(x=>new GetProductDto(x.Id,x.Name,x.Price)).ToList();
    }
    public List<GetProductDto> GetPrById(int c)
    {  return  _context.Products.
       
      Select(x=>new GetProductDto(x.Id,x.Name,x.Price)).ToList();
    }
 public void AddPrDto(AddProductDto c)
    {
        var mapped = new Product(c.Id, c.Name,c.Price);
        _context.Products.Add(mapped);
        _context.SaveChanges();
    }

 public bool  DeletePrById(int id)
    {
        var entity= _context.Products.Find(id);
         _context.Remove(entity);
         _context.SaveChanges();
        return true;
      
    }
    
 public void UpdateOrderrDto(AddProductDto c)
    { var entity= _context.Products.Find(c.Id);
    entity.Name=c.Name;
    entity.Price=c.Price;
   
        _context.Products.Update(entity);
        _context.SaveChanges();
    }

   public List<GetProductDto> GetCompanyByName(string name)
    {
        return _context.Products.
            Where(x => x.Name.ToLower().Contains(name.ToLower())).
            Select(x => new GetProductDto(x.Id,x.Name,x.Price)).ToList();
    }
}
