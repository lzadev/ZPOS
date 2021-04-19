using AutoMapper;
using ZPOS.UI.Entities;
using ZPOS.UI.Models;

namespace ZPOS.UI.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandVM>();

            CreateMap<CreateBrandVM, Brand>();
        }
    }
}
