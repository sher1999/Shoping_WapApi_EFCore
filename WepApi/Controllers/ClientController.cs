using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ClientController:ControllerBase
{
    private readonly ClientService _clientService;
  
    public ClientController(ClientService clientService)
    {
        _clientService=clientService;
    }

 [HttpGet("GetManual")]
        public List<ClientDto> GetManual()
        {
            return _clientService.GetClientDtosByManual();
        }
  
 [HttpGet("GetDapper")]
        public List<ClientDto> GetDapper()
        {
            return _clientService.GetClientDtoByDapper();
        }
[HttpGet("GetEFCore")]
        public List<ClientDto> GetEFCore()
        {
                return _clientService.GetClientDtoByEFCore();
        }
        [HttpGet("GetManualTime")]
        public object GetManualTime()
        {
                return _clientService.GetClientDtosByManualTime();
        }

  [HttpGet("GetDapperTime")]
        public object GeDapperTime()
        {
                return _clientService.GetClientDtoByDapperTime();
        }

    
    [HttpGet("GetEFCoreTime")]
        public object GetEFCoreTime()
        {
                return _clientService.GetClientDtoByEFCoreTime();
        }

        [HttpPost("Add")]
         public bool Add(AddClientDto c,int n)
                {
                        _clientService.AddClientDt(c,n);
                        return true;
                }

                 [HttpDelete("{id}")]
    public void Delete(int id ,int idd) => _clientService.DeleteClientById(id,idd);

}
