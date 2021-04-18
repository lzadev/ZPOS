using AutoMapper;
using ZPOS.UI.Entities;
using ZPOS.UI.Models;

namespace ZPOS.UI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryVM>();
            CreateMap<CreateCategoryVM, Category>();
        }
    }
}
