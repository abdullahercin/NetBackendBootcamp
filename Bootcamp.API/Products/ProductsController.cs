using Bootcamp.API.Controllers;
using Bootcamp.Service.Products;
using Bootcamp.Service.Products.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Products
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController(ProductService productService) : CustomBaseController
    {
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
    }
}
