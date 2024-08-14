using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCRM.API.Dtos.Client;
using ProjetoCRM.API.Dtos.Pet;
using ProjetoCRM.API.Models;
using ProjetoCRM.API.Services.PetService;

namespace ProjetoCRM.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    //creates a private attribute for pet service
    private readonly IPetService _petService;

    //constructor for the pet controller, using pet service as parameter
    public PetController(IPetService petService)
    {
        _petService = petService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetPetDto>>>> Get(int page = 1, int itemsPerPage = 10)
    {
        return Ok(await _petService.Get(page, itemsPerPage));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetPetDto>> GetById(int id)
    {
        try
        {
            var response = await _petService.GetById(id);

            return Ok(response);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    //POST to add pet to the database
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetPetDto>>>> Add(AddPetDto newPet)
    {
        return Ok(await _petService.Add(newPet));
    }

    //PUT to update a pet to the database
    [HttpPut]
    public async Task<ActionResult<ServiceResponse<GetPetDto>>> Update(UpdatePetDto updatePet)
    {
        try
        {
            var response = await _petService.Update(updatePet);

            return Ok(response);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    //DELETE to delete a pet by id
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<GetPetDto>>> Delete(int id)
    {
        try
        {
            await _petService.Delete(id);

            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
