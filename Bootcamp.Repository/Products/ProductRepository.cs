using Bootcamp.Domain.Products;
using Bootcamp.Service.Products;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Bootcamp.Repository.Products
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> IsExistName(string name)
        {
            return await _context.Products.AnyAsync(x => x.Name == name);
        }

        public async Task<bool> IsExistBarcode(string barcode)
        {
            return await _context.Products.AnyAsync(x => x.Barcode == barcode);
        }
    }
}
