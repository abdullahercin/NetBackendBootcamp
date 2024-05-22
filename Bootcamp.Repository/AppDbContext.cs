using Bootcamp.Domain.Categories;
using Bootcamp.Domain.ProductPrices;
using Bootcamp.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
    }
}
