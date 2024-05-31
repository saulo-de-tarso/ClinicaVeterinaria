using ProjetoCRM.API.Dtos.Cliente;
using ProjetoCRM.API.Models;
namespace ProjetoCRM.API.Services.ClientesService
{
    //interface para o serviço de clientes
    public interface IClientesService
    {
        //método para buscar a lista de clientes
        Task<ServiceResponse<List<GetClienteDto>>> GetListaClientes();

        //método para buscar um cliente específico por seu id
        Task<ServiceResponse<GetClienteDto>> GetClientePorId(int id);

        //método para adicionar cliente
        Task<ServiceResponse<List<GetClienteDto>>> AdicionarCliente(AddClienteDto novoCliente);

        //método para atualizar cliente
        Task<ServiceResponse<GetClienteDto>> AtualizarCliente(UpdateClienteDto atualizarCliente);

        //método para remover cliente por seu id
        Task<ServiceResponse<List<GetClienteDto>>> DeletarClientePorId(int id);


    }
}
