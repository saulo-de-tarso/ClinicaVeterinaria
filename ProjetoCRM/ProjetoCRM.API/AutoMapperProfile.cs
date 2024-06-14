using AutoMapper;
using ProjetoCRM.API.Dtos.Client;
using ProjetoCRM.API.Dtos.Pet;
using ProjetoCRM.API.Dtos.Appointment;
using ProjetoCRM.API.Models;

namespace ProjetoCRM.API
{
    //class to create auto mapper profile
    public class AutoMapperProfile : Profile
    {
        //constructor
        public AutoMapperProfile()
        {
            //Maps for client entity
            CreateMap<Client, GetClientDto>(); //Maps the getclientdto by entity client
            CreateMap<AddClientDto, Client>(); //Maps the client entity addclientdto
            CreateMap<UpdateClientDto, Client>(); //Maps the client entity by updateclientdto
            
            //Maps for pet entity
            CreateMap<AddPetDto, Pet>(); //Maps the petentity addpetdto
            CreateMap<UpdatePetDto, Pet>(); //Maps the petentity by updatepetdto

            //Maps for appointment entity
            CreateMap<Appointment, GetAppointmentDto>(); //Maps the getappointmentdto by entity appointment
            CreateMap<AddAppointmentDto, Appointment>(); //Maps the appointment entity addappointmentdto
            CreateMap<UpdateAppointmentDto, Appointment>(); //Maps the appointment entity by updateappointmentdto
        }
    }
}
