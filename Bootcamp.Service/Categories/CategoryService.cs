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

        public async Task<ResponseModelDto<CategoryDto>> GetById(int id)
        {
            var category = await categoryRepository.GetById(id); //Ürünün olup olmadığı filtre ile kontrol ediliyor.
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
