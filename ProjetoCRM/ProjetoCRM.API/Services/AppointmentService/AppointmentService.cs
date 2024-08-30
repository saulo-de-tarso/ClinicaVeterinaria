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
        public async Task<ServiceResponse<GetAppointmentDto>> Add(AddAppointmentDto newAppointment)
        {
            //criar uma instancia do modelo de service response
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            var appointment = new Appointment()
            {
                Value = newAppointment.Value,
                Description = newAppointment.Description,
                PetId = newAppointment.PetId
            };
            //adicionar a consulta ao banco de dados

            await _context.Appointment.AddAsync(appointment);
            await _context.SaveChangesAsync();
            var appointmentFromDb = await _context.Appointment.FirstOrDefaultAsync(c => c.Id == appointment.Id);
            serviceResponse.Data = new GetAppointmentDto()
            {
                Id = appointmentFromDb.Id,
                Value = appointmentFromDb.Value,
                Description = appointmentFromDb.Description,
                PetId = appointmentFromDb.PetId
            };
            //retornar o valor do service response
            return serviceResponse;
        }

        //get appointment by id
        public async Task<ServiceResponse<GetAppointmentDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();

            //exceptions for id not found
            try
            {
                var dbAppointment = await _context.Appointment
                    .Select(s => new GetAppointmentDto()
                    {
                        Id = s.Id,
                        Value = s.Value,
                        Description = s.Description,
                        PetId = s.PetId
                    })
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (dbAppointment is null)
                    throw new Exception($"Consulta com Id {id} não foi encontrado");

                serviceResponse.Data = dbAppointment;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        //get appointment list
        public async Task<ServiceResponse<List<GetAppointmentDto>>> Get(int page, int itemsPerPage)
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();

            var skip = (page - 1) * itemsPerPage;

            var dbAppointment = await _context.Appointment
                .Select(c => _mapper.Map<GetAppointmentDto>(c))
                .Skip(skip)
                .Take(itemsPerPage)
                .ToListAsync();

            serviceResponse.Data = dbAppointment;

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
        public async Task Delete(int id)
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(c => c.Id == id);
            if (appointment is null)
                throw new Exception($"Consulta com Id {id} não foi encontrado");

            _context.Appointment.Remove(appointment);

            await _context.SaveChangesAsync();

        }
    }
}
