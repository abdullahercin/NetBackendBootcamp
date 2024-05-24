using Bootcamp.API.Controllers;
using Bootcamp.API.Filters;
using Bootcamp.Domain.Products;
using Bootcamp.Service.Products;
using Bootcamp.Service.Products.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Products
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController(ProductService productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await productService.GetAll());
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await productService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDto request)
        {
            var result = await productService.CreateProduct(request);
            return CreateActionResult(result, nameof(GetById), new { id = result.Data });
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto request)
        {
            return CreateActionResult(await productService.UpdateProduct(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return CreateActionResult(await productService.DeleteProduct(id));
        }
    }
}
