using ProjetoCRM.API.Dtos.Client;
namespace ProjetoCRM.API.Services.ClientService
{
    public interface IClientService
    {
        Task<List<GetClientDto>> Get(int page, int itemsPerPage);

        Task<GetClientDto> GetById(int id);

        Task<GetClientDto> Add(AddClientDto newClient);

        Task<GetClientDto> Update(UpdateClientDto updateClient);

        Task Delete(int id);


    }
}
