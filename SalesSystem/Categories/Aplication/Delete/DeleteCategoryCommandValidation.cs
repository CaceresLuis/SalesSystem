using FluentValidation;

namespace SalesSystem.Categories.Aplication.Delete
{
    public class DeleteCategoryCommandValidation : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty();
        }
    }
}
