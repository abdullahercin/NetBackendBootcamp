using Bootcamp.Domain.Categories;
using Bootcamp.Service.Categories;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp.Repository.Categories
{
    public class CategoryRepository(AppDbContext context) : GenericRepository<Category>(context), ICategoryRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> IsExistName(string name)
        {
            return await _context.Categories.AnyAsync(x => x.Name == name);
        }
    }
}
