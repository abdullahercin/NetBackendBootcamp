using AutoMapper;
using Bootcamp.Domain.Products;
using Bootcamp.Service.Products.DTOs;

namespace Bootcamp.Service.Products.Mapping
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<ProductDto, Product>()
                .ReverseMap();
        }
    }
}
