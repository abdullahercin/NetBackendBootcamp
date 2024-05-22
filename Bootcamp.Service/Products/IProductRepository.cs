using Bootcamp.Domain.Products;

namespace Bootcamp.Service.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> IsExistName(string name);
        Task<bool> IsExistBarcode(string barcode);
    }
}
