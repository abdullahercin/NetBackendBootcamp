using Bootcamp.API.Controllers;
using Bootcamp.API.Filters;
using Bootcamp.Domain.Categories;
using Bootcamp.Service.Categories;
using Bootcamp.Service.Categories.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(CategoryService categoryService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await categoryService.GetAll());
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await categoryService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateDto request)
        {
            var result = await categoryService.Create(request);
            return CreateActionResult(result, nameof(GetById), new { id = result.Data });
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryUpdateDto request)
        {
            return CreateActionResult(await categoryService.Update(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return CreateActionResult(await categoryService.Delete(id));
        }
    }
}
