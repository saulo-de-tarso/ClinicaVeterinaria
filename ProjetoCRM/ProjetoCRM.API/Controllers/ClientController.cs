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
        //creates a private attribute for client service
        private readonly IClientService _clientService;

        //constructor for the client controller, using client service as parameter
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        //GET client list
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetClientDto>>>> Get()
        {
            return Ok(await _clientService.Get());
        }

        //GET client by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetClientDto>>> GetById(int id)
        {
            var response = await _clientService.GetById(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        //POST to add client to the database
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetClientDto>>>> Add(AddClientDto newClient)
        {
            return Ok(await _clientService.Add(newClient));
        }

        //PUT to update a client to the database
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetClientDto>>> Update(UpdateClientDto updateClient)
        {
            var response = await _clientService.Update(updateClient);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        //DELETE to delete a client by id
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetClientDto>>> Delete(int id)
        {
            var response = await _clientService.Delete(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }
    }
}
