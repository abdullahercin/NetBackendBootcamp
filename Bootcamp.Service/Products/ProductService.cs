using AutoMapper;
using Bootcamp.Domain.Products;
using Bootcamp.Service.Products.DTOs;
using System.Net;
using System.Collections.Immutable;

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

        public async Task<ResponseModelDto<NoContent>> UpdateProduct(int id, ProductUpdateDto request)
        {
            var hasEntity = await productRepository.GetById(id);
            hasEntity!.Name = request.Name;

            await productRepository.Update(hasEntity);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> DeleteProduct(int id)
        {
            await productRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<ProductDto>> GetById(int productId)
        {
            var product = await productRepository.GetById(productId);

            if (product == null)
            {
                return ResponseModelDto<ProductDto>.Fail($"{productId} ID numaralı ürün bulunamadı.",HttpStatusCode.NotFound);
            }

            var productDto = mapper.Map<ProductDto>(product);
            return ResponseModelDto<ProductDto>.Success(productDto);
        }

        public async Task<ResponseModelDto<ImmutableList<ProductDto>>> GetAll()
        {
            var products = await productRepository.GetAll();
            var productsDto = mapper.Map<List<ProductDto>>(products);
            return ResponseModelDto<ImmutableList<ProductDto>>.Success(productsDto.ToImmutableList());
        }
    }
}
