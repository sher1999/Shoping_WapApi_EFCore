using Domain.Entities;
using Domain.Dtos.CompanyDtos;
using Domain.Dtos.CustomerDtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController:ControllerBase
{
   private readonly CustomerService _customerService;

   public CustomerController(CustomerService customerService)
   {
    _customerService=customerService;
   }
 [HttpGet("Get")]
        public List<GetCostumerDto> GetCostumers()
        {
                return _customerService.GetCustomers();
        }
 [HttpGet("GetById")]
        public List<GetCostumerDto> GetCostumersById(int c)
        {
                return _customerService.GetCustomersById(c);
        }
[HttpPost("Add")]
        public bool AddCustomer(AddCostumerDto c)
        {
                _customerService.AddCostumerDto(c);
                return true;
        }
 [HttpDelete("{id}")]
    public void Delete(int id) => _customerService.DeleteCustumerById(id);

    [HttpPut("Update")]
    public void UpdateCostumerDto([FromBody] GetCostumerDto c) => _customerService.UpdateCostumerDto(c);
    
    [HttpGet("CustomerName")]
        public List<GetCostumerDto> GetCompanies([FromQuery] string name)
        {
                return _customerService.GetCompanyByName(name);
        }
}