using Bootcamp.Service.Categories.DTOs;
using FluentValidation;

namespace Bootcamp.Service.Categories.Validation
{
    public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori ismi yazılmalıdır.")
                .MaximumLength(100).WithMessage("Maksimum 100 karakter girilebilir.")
                .Must(name=>!ExistName(categoryRepository, name)).WithMessage("Kategori adı zaten var.");
        }

        public bool ExistName(ICategoryRepository categoryRepository, string name)
        {
            return categoryRepository.IsExistName(name).Result;
        }
    }
}
