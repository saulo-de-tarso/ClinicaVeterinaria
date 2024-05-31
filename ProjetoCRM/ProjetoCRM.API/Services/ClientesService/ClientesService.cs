using AutoMapper;
using ProjetoCRM.API.Data;
using ProjetoCRM.API.Dtos.Cliente;
using ProjetoCRM.API.Models;

namespace ProjetoCRM.API.Services.ClientesService
{
    public class ClientesService : IClientesService
    {
   
        //cria um atributo privado para o automapper, para mapear os serviço pelos Dtos
        private readonly IMapper _mapper;

        //cria um atributo privado para o datacontext
        private readonly DataContext _context;

        //construtor para o serviço de clientes, utilizando o Imapper e DataContext como parâmetros
        public ClientesService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        //método para adicionar cliente
        public async Task<ServiceResponse<List<GetClienteDto>>> AdicionarCliente(AddClienteDto novoCliente)
        {
            var serviceResponse = new ServiceResponse<List<GetClienteDto>>();
            _context.Clientes.Add(_mapper.Map<Clientes>(novoCliente));
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Clientes.Select(c => _mapper.Map<GetClienteDto>(c)).ToList();           
            return serviceResponse;
        }

        //método para buscar um cliente específico por seu id
        public async Task<ServiceResponse<GetClienteDto>> GetClientePorId(int id)
        {
            var serviceResponse = new ServiceResponse<GetClienteDto>();

            //try-catch com exceções caso o id do cliente não seja encontrado
            try
            {
                var dbCliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
                if (dbCliente is null)
                    throw new Exception($"Cliente com Id {id} não foi encontrado");
                serviceResponse.Data = _mapper.Map<GetClienteDto>(dbCliente);   
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        //método para buscar a lista de clientes
        public async Task<ServiceResponse<List<GetClienteDto>>> GetListaClientes()
        {
            var serviceResponse = new ServiceResponse<List<GetClienteDto>>();
            var dbClientes = await _context.Clientes.ToListAsync();
            serviceResponse.Data = dbClientes.Select(c => _mapper.Map<GetClienteDto>(c)).ToList();
            return serviceResponse;
        }

        //método para atualizar cliente pelo id
        public async Task<ServiceResponse<GetClienteDto>> AtualizarCliente(UpdateClienteDto atualizarCliente)
        {
            var serviceResponse = new ServiceResponse<GetClienteDto>();
            //try-catch com exceções caso o id do cliente não seja encontrado
            try
            {
                
                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == atualizarCliente.Id);
                if (cliente is null)
                    throw new Exception($"Cliente com Id {atualizarCliente.Id} não foi encontrado");

                _mapper.Map(atualizarCliente, cliente);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = _mapper.Map<GetClienteDto>(cliente);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        //método para deletar cliente pelo id
        public async Task<ServiceResponse<List<GetClienteDto>>> DeletarClientePorId(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetClienteDto>>();
            //try-catch com exceções caso o id do cliente não seja encontrado
            try
            {

                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
                if (cliente is null)
                    throw new Exception($"Cliente com Id {id} não foi encontrado");

                _context.Clientes.Remove(cliente);

                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Clientes.Select(c => _mapper.Map<GetClienteDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
