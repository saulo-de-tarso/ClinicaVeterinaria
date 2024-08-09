
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoCRM.API.Data;
using ProjetoCRM.API.Dtos.Client;
using ProjetoCRM.API.Dtos.Pet;
using ProjetoCRM.API.Models;

namespace ProjetoCRM.API.Services.PetService
{
    public class PetService : IPetService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PetService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetPetDto> Add(AddPetDto newPet)
        {
            var clientModel = _mapper.Map<Pet>(newPet);

            await _context.Pet.AddAsync(clientModel);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<GetPetDto>(clientModel);

            return response;
        }
        public async Task<GetPetDto> GetById(int id)
        {
            var pet = await _context.Pet.AsNoTracking().Include(i => i.Owner).Where(w => w.Id == id).Select(s => new GetPetDto()
            {
                Id = s.Id,
                Name = s.Name,
                BirthDate = s.BirthDate,
                Specie = s.Specie,
                Race = s.Race,
                Owner = new PetOwnerDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                },
            }).FirstOrDefaultAsync();
            if (pet is null)
                throw new KeyNotFoundException($"Pet com Id {id} não foi encontrado");
            return pet;
        }
        public async Task<List<GetPetDto>> Get(int page, int itemsPerPage)
        {
            int skip = (page - 1) * itemsPerPage;

            var serviceResponse = new ServiceResponse<List<GetPetDto>>();

            var pets = await _context.Pet.AsNoTracking().Include(i => i.Owner).Select(s => new GetPetDto()
               
               {
                    Id = s.Id,
                    Name = s.Name,
                    BirthDate = s.BirthDate,
                    Specie = s.Specie,
                    Race = s.Race,
                    Owner = new PetOwnerDto()
                    {
                        Id = s.Id,
                        Name = s.Name,
                    },
                })
               .Skip(skip)
               .Take(itemsPerPage)
               .ToListAsync();

            return pets;
        }

        public async Task<GetPetDto> Update(UpdatePetDto updatePet)
        {
            var pet = await _context.Pet.FirstOrDefaultAsync(c => c.Id == updatePet.Id);

            if (pet is null)
                throw new KeyNotFoundException($"Pet com Id {updatePet.Id} não foi encontrado");

            _mapper.Map(updatePet, pet);

            await _context.SaveChangesAsync();

            var response = _mapper.Map<GetPetDto>(pet);

            return response;
        }
        public async Task Delete(int id)
        {
            var petExists = await _context.Pet.AnyAsync(c => c.Id == id);

            if (petExists)
                throw new KeyNotFoundException($"Pet com Id {id} não foi encontrado");

            var _ = _context.Pet.Where(c => c.Id == id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();
        }
    }
}
