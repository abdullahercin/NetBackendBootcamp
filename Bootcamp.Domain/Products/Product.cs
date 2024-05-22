using Bootcamp.Domain.Categories;
using Bootcamp.Domain.ProductPrices;

namespace Bootcamp.Domain.Products
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string Barcode { get; set; } = default!;
        public int CategoryId { get; set; } = default!;
        public decimal VatRate { get; set; }
        public virtual Category Category { get; set; } = default!;
        public virtual IEnumerable<ProductPrice>? ProductPrices { get; set; } 
    }
}
