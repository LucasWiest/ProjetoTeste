using AutoMapper;
using ProjetoTeste.Models;

namespace ProjetoTeste.Views.Client
{
    public class ClientProfileMap : Profile
    {

        public ClientProfileMap() 
        { 
            CreateMap<Clients, ClientView>().ReverseMap(); 


            CreateMap<Clients, ClientSimpleView>()
                .ForMember(
                    dest => dest.Name, 
                    src => src.MapFrom(x => x.Name)
                ) 
                .ForMember(
                    dest => dest.Birth, 
                    src => src.MapFrom(x => x.Birth.AddDays(4))
                 ) 
                .ForMember(
                    dest => dest.Id, 
                    src => src.MapFrom(x => x.Id)
                );
        }
    }
}
