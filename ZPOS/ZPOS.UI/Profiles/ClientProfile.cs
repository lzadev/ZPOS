using AutoMapper;
using ZPOS.UI.Entities;
using ZPOS.UI.Models;

namespace ZPOS.UI.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientVM>()
                .ForMember(c => c.CompletedName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<CreateClientVM, Client>();

            CreateMap<Client, UpdateClienteVM>();

            CreateMap<UpdateClienteVM, Client>();
        }
    }
}
