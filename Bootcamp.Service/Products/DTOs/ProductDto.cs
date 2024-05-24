using Bootcamp.Domain.Categories;
using Bootcamp.Domain.ProductPrices;

namespace Bootcamp.Service.Products.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string Barcode { get; set; } = default!;
        public int CategoryId { get; set; } = default!;
        public decimal VatRate { get; set; }
        public virtual Category Category { get; set; } = default!;
        public virtual IEnumerable<ProductPrice>? ProductPrices { get; set; }
    }
}
