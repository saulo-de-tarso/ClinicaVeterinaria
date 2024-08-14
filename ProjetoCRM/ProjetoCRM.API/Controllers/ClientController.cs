using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCRM.API.Dtos.Client;
using ProjetoCRM.API.Models;
using ProjetoCRM.API.Services.ClientService;

namespace ProjetoCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetClientDto>>>> Get(int page = 1, int itemsPerPage = 10)
        {
            return Ok(await _clientService.Get(page, itemsPerPage));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetClientDto>>> GetById(int id)
        {
            try
            {
                var response = await _clientService.GetById(id);

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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetClientDto>>>> Add(AddClientDto newClient)
        {
            return Ok(await _clientService.Add(newClient));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetClientDto>>> Update(UpdateClientDto updateClient)
        {
            try
            {
                var response = await _clientService.Update(updateClient);

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

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetClientDto>>> Delete(int id)
        {
            try
            {
                await _clientService.Delete(id);

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
}
