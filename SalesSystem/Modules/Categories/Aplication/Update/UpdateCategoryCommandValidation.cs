using FluentValidation;

namespace SalesSystem.Modules.Categories.Aplication.Update
{
    public class UpdateCategoryCommandValidation : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidation()
        {
            RuleFor(c => c.Name)
                 .NotEmpty()
                 .MaximumLength(100);
        }
    }
}
