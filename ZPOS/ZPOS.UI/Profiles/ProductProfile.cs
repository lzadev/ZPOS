using AutoMapper;
using ZPOS.UI.Entities;
using ZPOS.UI.Models;

namespace ZPOS.UI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductVM>()
                .ForMember(p => p.Category, opt => opt.MapFrom(src => src.Categories.Name))
                .ForMember(p => p.Brand, opt => opt.MapFrom(src => src.Brands.Name));

            CreateMap<CreateProductVM, Product>().ForMember(p => p.Categories, opt => opt.Ignore())
                .ForMember(p => p.Brands, opt => opt.Ignore());

            CreateMap<UpdateProductVM, Product>().ForMember(p => p.Categories, opt => opt.Ignore())
                .ForMember(p => p.Brands, opt => opt.Ignore());
        }
    }
}
