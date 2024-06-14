using AutoMapper;
using ProjetoCRM.API.Data;
using ProjetoCRM.API.Dtos.Client;
using ProjetoCRM.API.Models;

namespace ProjetoCRM.API.Services.ClientService
{
    public class ClientService : IClientService
    {
   
        //private attribute for automapper, to map service from dtos
        private readonly IMapper _mapper;

        //private attribute for datacontext
        private readonly DataContext _context;

        //client service constructor
        public ClientService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        //add client 
        public async Task<ServiceResponse<List<GetClientDto>>> Add(AddClientDto newClient)
        {
            var serviceResponse = new ServiceResponse<List<GetClientDto>>();
            _context.Client.Add(_mapper.Map<Client>(newClient));
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Client.Select(c => _mapper.Map<GetClientDto>(c)).ToList();           
            return serviceResponse;
        }

        //get client by id
        public async Task<ServiceResponse<GetClientDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetClientDto>();

            //exceptions for id not found
            try
            {
                var dbClient = await _context.Client.FirstOrDefaultAsync(c => c.Id == id);
                if (dbClient is null)
                    throw new Exception($"Cliente com Id {id} não foi encontrado");
                serviceResponse.Data = _mapper.Map<GetClientDto>(dbClient);   
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        //get client list
        public async Task<ServiceResponse<List<GetClientDto>>> Get()
        {
            var serviceResponse = new ServiceResponse<List<GetClientDto>>();
            var dbClient = await _context.Client.ToListAsync();
            serviceResponse.Data = dbClient.Select(c => _mapper.Map<GetClientDto>(c)).ToList();
            return serviceResponse;
        }

        //update client
        public async Task<ServiceResponse<GetClientDto>> Update(UpdateClientDto updateClient)
        {
            var serviceResponse = new ServiceResponse<GetClientDto>();
            //exceptions for id not found
            try
            {
                
                var client = await _context.Client.FirstOrDefaultAsync(c => c.Id == updateClient.Id);
                if (client is null)
                    throw new Exception($"Cliente com Id {updateClient.Id} não foi encontrado");

                _mapper.Map(updateClient, client);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = _mapper.Map<GetClientDto>(client);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        //delete client
        public async Task<ServiceResponse<List<GetClientDto>>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetClientDto>>();
            //exceptions for id not found
            try
            {

                var client = await _context.Client.FirstOrDefaultAsync(c => c.Id == id);
                if (client is null)
                    throw new Exception($"Cliente com Id {id} não foi encontrado");

                _context.Client.Remove(client);

                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Client.Select(c => _mapper.Map<GetClientDto>(c)).ToListAsync();
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
