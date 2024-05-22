using AutoMapper;
using Bootcamp.Domain.Categories;
using Bootcamp.Service.Categories.DTOs;

namespace Bootcamp.Service.Categories.Mapping
{
    public class CategoryDtoMapProfile : Profile
    {
        public CategoryDtoMapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
