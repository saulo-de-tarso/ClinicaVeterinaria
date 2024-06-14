using ProjetoCRM.API.Dtos.Client;
using ProjetoCRM.API.Models;
namespace ProjetoCRM.API.Services.ClientService
{
    //client service interface
    public interface IClientService
    {
        //GET client list
        Task<ServiceResponse<List<GetClientDto>>> Get();

        //GET client by Id
        Task<ServiceResponse<GetClientDto>> GetById(int id);

        //Add client
        Task<ServiceResponse<List<GetClientDto>>> Add(AddClientDto newClient);

        //Update client
        Task<ServiceResponse<GetClientDto>> Update(UpdateClientDto updateClient);

        //Delete client
        Task<ServiceResponse<List<GetClientDto>>> Delete(int id);


    }
}
