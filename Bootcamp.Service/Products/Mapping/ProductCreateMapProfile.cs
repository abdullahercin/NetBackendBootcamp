using AutoMapper;
using Bootcamp.Domain.Products;
using Bootcamp.Service.Products.DTOs;

namespace Bootcamp.Service.Products.Mapping
{
    public class ProductCreateMapProfile : Profile
    {
        public ProductCreateMapProfile()
        {
            CreateMap<ProductCreateDto, Product>()
                .ReverseMap();
        }
    }
}
