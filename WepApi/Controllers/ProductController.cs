using Domain.Entities;
using Domain.Dtos.ProductDtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController:ControllerBase
{
   private readonly ProductService _productService;

   public ProductController(ProductService productService)
   {
    _productService=productService;
   }
 [HttpGet("Get")]
        public List<GetProductDto> GetCostumers()
        {
                return _productService.GetPr();
        }
 [HttpGet("GetById")]
        public List<GetProductDto> GetCostumersById(int c)
        {
                return _productService.GetPrById(c);
        }
[HttpPost("Add")]
        public bool AddCustomer(AddProductDto c)
        {
                _productService.AddPrDto(c);
                return true;
        }
 [HttpDelete("{id}")]
    public void Delete(int id) => _productService.DeletePrById(id);

    [HttpPut("Update")]
    public void UpdateCostumerDto([FromBody] AddProductDto c) => _productService.UpdateOrderrDto(c);

   [HttpGet("ProductName")]
        public List<GetProductDto> GetCompanies([FromQuery] string name)
        {
                return _productService.GetCompanyByName(name);
        }

}