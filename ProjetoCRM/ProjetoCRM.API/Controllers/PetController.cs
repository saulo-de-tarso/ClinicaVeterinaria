//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ProjetoCRM.API.Dtos.Pet;
//using ProjetoCRM.API.Models;
//using ProjetoCRM.API.Services.PetService;

//namespace ProjetoCRM.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PetController : ControllerBase
//    {
//        //creates a private attribute for pet service
//        private readonly IPetService _petService;

//        //constructor for the pet controller, using pet service as parameter
//        public PetController(IPetService petService)
//        {
//            _petService = petService;
//        }

//        //POST to add pet to the database
//        [HttpPost]
//        public async Task<ActionResult<ServiceResponse<List<GetPetDto>>>> Add(AddPetDto newPet)
//        {
//            return Ok(await _petService.Add(newPet));
//        }

//        //PUT to update a pet to the database
//        [HttpPut]
//        public async Task<ActionResult<ServiceResponse<GetPetDto>>> Update(UpdatePetDto updatePet)
//        {
//            var response = await _petService.Update(updatePet);
//            if (response.Data is null)
//                return NotFound(response);
//            return Ok(response);
//        }

//        //DELETE to delete a pet by id
//        [HttpDelete]
//        public async Task<ActionResult<ServiceResponse<GetPetDto>>> Delete(int id)
//        {
//            var response = await _petService.Delete(id);
//            if (response.Data is null)
//                return NotFound(response);
//            return Ok(response);
//        }
//    }
//}
