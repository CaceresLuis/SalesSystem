using FluentValidation;

namespace SalesSystem.Modules.Categories.Aplication.Delete
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
