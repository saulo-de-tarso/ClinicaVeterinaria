﻿using ProjetoCRM.API.Dtos.Appointment;
using ProjetoCRM.API.Models;

namespace ProjetoCRM.API.Services.AppointmentService
{
    public interface IAppointmentService
    {
        //GET appointment list
        Task<ServiceResponse<List<GetAppointmentDto>>> Get(int page, int itemsPerPage);

        //GET appointment by Id
        Task<ServiceResponse<GetAppointmentDto>> GetById(int id);

        //Add appointment
        Task<ServiceResponse<GetAppointmentDto>> Add(AddAppointmentDto newAppointment);

        //Update appointment
        Task<ServiceResponse<GetAppointmentDto>> Update(UpdateAppointmentDto updateAppointment);

        //Delete appointment
        Task Delete(int id);
    }
}
