using ProjetoCRM.API.Dtos.Client;
using ProjetoCRM.API.Dtos.Pet;

namespace ProjetoCRM.API.Services.PetService;

public interface IPetService
{
    Task<List<GetPetDto>> Get(int page, int itemsPerPage);
    Task<GetPetDto> GetById(int id);
    Task<GetPetDto> Add(AddPetDto newPet);
    Task<GetPetDto> Update(UpdatePetDto updatePet);
    Task Delete(int id);
}
