using FluentValidation;

namespace SalesSystem.ProductCategories.Aplication.Create
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(pc => pc.CategoriesId).NotEmpty();
            RuleFor(pc => pc.ProductId).NotEmpty();
        }
    }
}
