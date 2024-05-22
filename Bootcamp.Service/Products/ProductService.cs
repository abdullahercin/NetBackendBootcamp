using AutoMapper;
using Bootcamp.Domain.Products;
using Bootcamp.Service.Products.DTOs;

namespace Bootcamp.Service.Products
{
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        public async Task<ResponseModelDto<int>> CreateProduct(ProductCreateDto request)
        {
            var productEntity = mapper.Map<Product>(request);
            var result = await productRepository.Create(productEntity);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<int>.Success(result.Id);
        }

        public async Task<ResponseModelDto<ProductDto>> GetById(int productId)
        {
            var product = await productRepository.GetById(productId); //Ürünün olup olmadığı filtre ile kontrol ediliyor.
            var productDto = mapper.Map<ProductDto>(product);
            return ResponseModelDto<ProductDto>.Success(productDto);
        }
    }
}
