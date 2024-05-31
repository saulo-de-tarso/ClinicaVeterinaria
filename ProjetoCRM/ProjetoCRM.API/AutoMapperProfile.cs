using AutoMapper;
using ProjetoCRM.API.Dtos.Cliente;
using ProjetoCRM.API.Models;

namespace ProjetoCRM.API
{
    //classe para criar o perfil do automapper
    public class AutoMapperProfile : Profile
    {
        //construtor
        public AutoMapperProfile()
        {
            CreateMap<Clientes, GetClienteDto>(); //Mapeia o getclientesdto baseado nos clientes
            CreateMap<AddClienteDto, Clientes>(); //Mapeia os clientes baseado no addclientesdto
            CreateMap<UpdateClienteDto, Clientes>(); //Mapeia os clientes baseado no updateclientesdto
        }
    }
}
