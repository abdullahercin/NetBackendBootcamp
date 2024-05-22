using AutoMapper;
using Bootcamp.Domain.Categories;
using Bootcamp.Service.Categories.DTOs;

namespace Bootcamp.Service.Categories.Mapping
{
    public class CategoryCreateMapProfile : Profile
    {
        public CategoryCreateMapProfile()
        {
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
        }
    }
}
