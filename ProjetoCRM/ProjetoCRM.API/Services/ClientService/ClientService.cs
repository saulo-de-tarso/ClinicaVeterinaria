using AutoMapper;
using ProjetoCRM.API.Data;
using ProjetoCRM.API.Dtos.Client;
using ProjetoCRM.API.Models;

namespace ProjetoCRM.API.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ClientService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetClientDto> Add(AddClientDto newClient)
        {
            var clientModel = _mapper.Map<Client>(newClient);

            await _context.Client.AddAsync(clientModel);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<GetClientDto>(clientModel);

            return response;
        }

        public async Task<GetClientDto> GetById(int id)
        {
            var client = await _context.Client
                   .Select(clientModel => new GetClientDto()
                   {
                       Id = clientModel.Id,
                       Name = clientModel.Name,
                       Cpf = clientModel.Cpf,
                       Email = clientModel.Email
                   })
                   .FirstOrDefaultAsync(c => c.Id == id);

            if (client is null)
                throw new KeyNotFoundException($"Cliente com Id {id} não foi encontrado");

            return client;
        }

        public async Task<List<GetClientDto>> Get(int page, int itemsPerPage)
        {
            int skip = (page - 1) * itemsPerPage;

            var serviceResponse = new ServiceResponse<List<GetClientDto>>();

            var clients = await _context.Client
               .Select(clientModel => new GetClientDto()
               {
                   Id = clientModel.Id,
                   Name = clientModel.Name,
                   Cpf = clientModel.Cpf,
                   Email = clientModel.Email
               })
               .Skip(skip)
               .Take(itemsPerPage)
               .ToListAsync();
            
            return clients;
        }

        public async Task<GetClientDto> Update(UpdateClientDto updateClient)
        {
            var client = await _context.Client.FirstOrDefaultAsync(c => c.Id == updateClient.Id);

            if (client is null)
                throw new KeyNotFoundException($"Cliente com Id {updateClient.Id} não foi encontrado");

            _mapper.Map(updateClient, client);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<GetClientDto>(client);

            return response;
        }

        public async Task Delete(int id)
        {
            var clientExists = await _context.Client.AnyAsync(c => c.Id == id);

            if (clientExists)
                throw new KeyNotFoundException($"Cliente com Id {id} não foi encontrado");

            var _ = _context.Client.Where(c => c.Id == id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();
        }
    }
}
