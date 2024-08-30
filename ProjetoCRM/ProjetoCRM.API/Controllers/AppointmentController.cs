using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCRM.API.Dtos.Appointment;
using ProjetoCRM.API.Models;
using ProjetoCRM.API.Services.AppointmentService;

namespace ProjetoCRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        //creates a private attribute for appointment service
        private readonly IAppointmentService _appointmentService;

        //constructor for the appointment controller, using appointment service as parameter
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        //GET appointment list
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> Get(int page = 1, int itemsPerPage = 10)
        {
            return Ok(await _appointmentService.Get(page, itemsPerPage));
        }

        //GET appointment by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAppointmentDto>>> GetById(int id)
        {
            var response = await _appointmentService.GetById(id);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        //POST to add appointment to the database
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> Add(AddAppointmentDto newAppointment)
        {
            return Ok(await _appointmentService.Add(newAppointment));
        }

        //PUT to update an appointment to the database
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetAppointmentDto>>> Update(UpdateAppointmentDto updateAppointment)
        {
            var response = await _appointmentService.Update(updateAppointment);
            if (response.Data is null)
                return NotFound(response);
            return Ok(response);
        }

        //DELETE to delete an appointment by id
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _appointmentService.Delete(id);
         
            return Ok();
        }
    }
}
