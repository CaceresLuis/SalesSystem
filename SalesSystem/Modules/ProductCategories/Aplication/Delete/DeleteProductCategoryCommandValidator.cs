using FluentValidation;

namespace SalesSystem.Modules.ProductCategories.Aplication.Delete
{
    public class DeleteProductCategoryCommandValidator : AbstractValidator<DeleteProductCategoryCommand>
    {
        public DeleteProductCategoryCommandValidator()
        {
            RuleFor(pc => pc.CategoriesId).NotEmpty();
            RuleFor(pc => pc.ProductId).NotEmpty();
        }
    }
}
