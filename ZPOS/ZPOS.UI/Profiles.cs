using AutoMapper;
using ZPOS.UI.Entities;
using ZPOS.UI.Models;

namespace ZPOS.UI
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Product, ProductVM>()
                .ForMember(p => p.Category, opt => opt.MapFrom(src => src.Categories.Name))
                .ForMember(p => p.Brand, opt => opt.MapFrom(src => src.Brands.Name));
        }
    }
}
