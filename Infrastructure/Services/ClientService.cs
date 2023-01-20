using System.Diagnostics;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Data;
using  Dapper;
using Npgsql;
using Microsoft.EntityFrameworkCore; 

namespace Infrastructure.Services;

public class ClientService:GenericCrud<Client>
{
     private readonly DataContext _context;

     private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Test_Db;User Id=postgres;Password=admin;";
   
public ClientService(DataContext context ):base(context)
{
    _context = context;
}





    public List<ClientDto> GetClientDtosByManual()
    {
        string sql = "SELECT * From public.\"Clients\"";
        var clients = new List<ClientDto>();
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            
            connection.Open();
            using (var command = new NpgsqlCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var clientDto = new ClientDto()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                            LastName = reader.GetString(reader.GetOrdinal("lastname")),
                            Address = reader.GetString(reader.GetOrdinal("address")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            Phone = reader.GetString(reader.GetOrdinal("phone"))
                        };
                        clients.Add(clientDto);
                    }
                }
            }
          
            connection.Close();
        }

        return clients;
    }


    public object GetClientDtosByManualTime()
    {
        string sql = "SELECT * From public.\"Clients\"";
        var clients = new List<ClientDto>();
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();
            using (var command = new NpgsqlCommand(sql, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var clientDto = new ClientDto()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                            LastName = reader.GetString(reader.GetOrdinal("lastname")),
                            Address = reader.GetString(reader.GetOrdinal("address")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            Phone = reader.GetString(reader.GetOrdinal("phone"))
                        };
                        clients.Add(clientDto);
                    }
                }
            }
            sw.Stop();
            return($"Geting Manual Time :  {sw.ElapsedMilliseconds}");
            connection.Close();
        }

        return clients;
    }




  public List<ClientDto> GetClientDtoByDapper()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * From public.\"Clients\"";
            var result = connection.Query<ClientDto>(sql);

            return result.ToList();
        }

    }
  public object GetClientDtoByDapperTime()
    {
        var sw = new Stopwatch();
        sw.Start();
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * From public.\"Clients\"";
            var result = connection.Query<ClientDto>(sql);

            sw.Stop();
             return $"Geting Dapper Time :   {sw.ElapsedMilliseconds}";
           
        }

    }




 public object GetClientDtoByEFCoreTime()
    {
         var sw = new Stopwatch();
            sw.Start();
           
        var list =  _context.Clients.Select(x=>new ClientDto(x.Id,x.FirstName,x.LastName,x.Address,x.Phone,x.Email)).ToList();    
            
         sw.Stop();
         return  $"Geting EF Core Time :  {sw.ElapsedMilliseconds}";
    }
 public List<ClientDto> GetClientDtoByEFCore()
    {
        
         return  _context.Clients.Select(x=>new ClientDto(x.Id,x.FirstName,x.LastName,x.Address,x.Phone,x.Email)).ToList();    
             
    }

    
    




 public bool  DeleteClientById(int id, int idd)
    {  
           for (int i = id; i < idd; i++)
        {
        var entity= _context.Clients.Find(i);
         _context.Remove(entity);
         _context.SaveChanges();
        
        }
        return true;
    }





    public void AddClientDt(AddClientDto c, int n)
    {   
        for (int i = 0; i < n; i++)
        {
             var mapped = new Client(c.Id, c.FirstName,c.LastName,c.Address,c.Phone,c.Email );
        _context.Clients.Add(mapped);
        _context.SaveChanges();
        }
       
    }
}

