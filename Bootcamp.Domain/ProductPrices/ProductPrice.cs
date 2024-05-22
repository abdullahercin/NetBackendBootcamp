using Bootcamp.Domain.Products;

namespace Bootcamp.Domain.ProductPrices
{
    public class ProductPrice : BaseEntity<int>
    {
        public decimal Price { get; set; }
        public PriceType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;
    }

    public enum PriceType : byte
    {
        Alış = 1,
        Satış = 2
    }
}
