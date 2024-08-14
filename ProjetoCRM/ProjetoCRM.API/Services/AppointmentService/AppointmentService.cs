using AutoMapper;
using ProjetoCRM.API.Data;
using ProjetoCRM.API.Dtos.Appointment;
using ProjetoCRM.API.Models;

namespace ProjetoCRM.API.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {

        //private attribute for automapper, to map service from dtos
        private readonly IMapper _mapper;

        //private attribute for datacontext
        private readonly DataContext _context;

        //appointment service constructor
        public AppointmentService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        //add appointment 
        public async Task<ServiceResponse<List<GetAppointmentDto>>> Add(AddAppointmentDto newAppointment)
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            _context.Appointment.Add(_mapper.Map<Appointment>(newAppointment));
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Appointment.Select(c => _mapper.Map<GetAppointmentDto>(c)).ToList();
            return serviceResponse;
        }

        //get appointment by id
        public async Task<ServiceResponse<GetAppointmentDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();

            //exceptions for id not found
            try
            {
                var dbAppointment = await _context.Appointment.FirstOrDefaultAsync(c => c.Id == id);
                if (dbAppointment is null)
                    throw new Exception($"Consulta com Id {id} não foi encontrado");
                serviceResponse.Data = _mapper.Map<GetAppointmentDto>(dbAppointment);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        //get appointment list
        public async Task<ServiceResponse<List<GetAppointmentDto>>> Get()
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            var dbAppointment = await _context.Appointment.ToListAsync();
            serviceResponse.Data = dbAppointment.Select(c => _mapper.Map<GetAppointmentDto>(c)).ToList();
            return serviceResponse;
        }

        //update appointment
        public async Task<ServiceResponse<GetAppointmentDto>> Update(UpdateAppointmentDto updateAppointment)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            //exceptions for id not found
            try
            {

                var appointment = await _context.Appointment.FirstOrDefaultAsync(c => c.Id == updateAppointment.Id);
                if (appointment is null)
                    throw new Exception($"Consulta com Id {updateAppointment.Id} não foi encontrado");

                _mapper.Map(updateAppointment, appointment);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetAppointmentDto>(appointment);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        //delete appointment
        public async Task<ServiceResponse<List<GetAppointmentDto>>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            //exceptions for id not found
            try
            {

                var appointment = await _context.Appointment.FirstOrDefaultAsync(c => c.Id == id);
                if (appointment is null)
                    throw new Exception($"Consulta com Id {id} não foi encontrado");

                _context.Appointment.Remove(appointment);

                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Appointment.Select(c => _mapper.Map<GetAppointmentDto>(c)).ToListAsync();
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
