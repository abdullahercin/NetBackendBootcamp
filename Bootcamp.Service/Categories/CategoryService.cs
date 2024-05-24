using AutoMapper;
using System.Net;
using Bootcamp.Domain.Categories;
using Bootcamp.Service.Categories.DTOs;
using System.Collections.Immutable;

namespace Bootcamp.Service.Categories
{
    public class CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        public async Task<ResponseModelDto<int>> Create(CategoryCreateDto request)
        {
            var entity = mapper.Map<Category>(request);
            var result = await categoryRepository.Create(entity);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<int>.Success(result.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int categoryId, CategoryUpdateDto request)
        {
            var hasCategory= await categoryRepository.GetById(categoryId);
            hasCategory!.Name= request.Name;

            await categoryRepository.Update(hasCategory);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int categoryId)
        {
            await categoryRepository.Delete(categoryId);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<CategoryDto>> GetById(int categoryId)
        {
            var category = await categoryRepository.GetById(categoryId); 
            if (category== null)
            {
                return ResponseModelDto<CategoryDto>.Fail($"{categoryId} ID numaralı ürün bulunamadı.", HttpStatusCode.NotFound);
            }
            var categoryDto = mapper.Map<CategoryDto>(category);
            return ResponseModelDto<CategoryDto>.Success(categoryDto);
        }

        public async Task<ResponseModelDto<ImmutableList<CategoryDto>>> GetAll()
        {
            var categories = await categoryRepository.GetAll();
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories);
            return ResponseModelDto<ImmutableList<CategoryDto>>.Success(categoriesDto.ToImmutableList());
        }
    }
}
