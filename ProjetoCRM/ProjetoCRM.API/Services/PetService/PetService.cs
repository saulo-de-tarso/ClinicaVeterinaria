//using AutoMapper;
//using ProjetoCRM.API.Data;
//using ProjetoCRM.API.Dtos.Pet;
//using ProjetoCRM.API.Models;

//namespace ProjetoCRM.API.Services.PetService
//{
//    public class PetService : IPetService
//    {

//        //private attribute for automapper, to map services from dtos
//        private readonly IMapper _mapper;

//        //private attribute for datacontext
//        private readonly DataContext _context;

//        //pet service constructor
//        public PetService(IMapper mapper, DataContext context)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        //add pet 
//        public async Task<ServiceResponse<List<GetPetDto>>> Add(AddPetDto newPet)
//        {
//            var serviceResponse = new ServiceResponse<List<GetPetDto>>();
//            _context.Pet.Add(_mapper.Map<Pet>(newPet));
//            await _context.SaveChangesAsync();
//            serviceResponse.Data = _context.Pet.Select(c => _mapper.Map<GetPetDto>(c)).ToList();
//            return serviceResponse;
//        }

//        //update pet
//        public async Task<ServiceResponse<GetPetDto>> Update(UpdatePetDto updatePet)
//        {
//            var serviceResponse = new ServiceResponse<GetPetDto>();
//            //exceptions for id not found
//            try
//            {

//                var pet = await _context.Pet.FirstOrDefaultAsync(c => c.Id == updatePet.Id);
//                if (pet is null)
//                    throw new Exception($"Pet com Id {updatePet.Id} não foi encontrado");

//                _mapper.Map(updatePet, pet);
//                await _context.SaveChangesAsync();

//                serviceResponse.Data = _mapper.Map<GetPetDto>(pet);
//            }
//            catch (Exception ex)
//            {
//                serviceResponse.Success = false;
//                serviceResponse.Message = ex.Message;
//            }

//            return serviceResponse;
//        }

//        //delete pet
//        public async Task<ServiceResponse<List<GetPetDto>>> Delete(int id)
//        {
//            var serviceResponse = new ServiceResponse<List<GetPetDto>>();
//            //exceptions for id not found
//            try
//            {

//                var pet = await _context.Pet.FirstOrDefaultAsync(c => c.Id == id);
//                if (pet is null)
//                    throw new Exception($"Pet com Id {id} não foi encontrado");

//                _context.Pet.Remove(pet);

//                await _context.SaveChangesAsync();
//                serviceResponse.Data = await _context.Pet.Select(c => _mapper.Map<GetPetDto>(c)).ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                serviceResponse.Success = false;
//                serviceResponse.Message = ex.Message;
//            }

//            return serviceResponse;
//        }
//    }
//}
