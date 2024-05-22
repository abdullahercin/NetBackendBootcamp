using Bootcamp.Service.Products.DTOs;
using FluentValidation;

namespace Bootcamp.Service.Products.Validation
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator(IProductRepository productRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün ismi yazılmalıdır.")
                .MaximumLength(100).WithMessage("Maksimum 100 karakter girilebilir.")
                .Must(name=>ExistName(productRepository, name)).WithMessage("Ürün adı zaten var.");
           
            RuleFor(x => x.Barcode)
                .MaximumLength(50).WithMessage("Maksimum 50 karakter girilebilir.")
                .Must(barcode=>productRepository.IsExistBarcode(barcode).Result).WithMessage("Barkod zaten tanımlı.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Kategori seçilmelidir.");
        }

        public bool ExistName(IProductRepository productRepository, string name)
        {
            return productRepository.IsExistName(name).Result;
        }

        public async Task<bool> ExistBarcode(IProductRepository productRepository, string name)
        {
            return await productRepository.IsExistName(name);
        }
    }
}
