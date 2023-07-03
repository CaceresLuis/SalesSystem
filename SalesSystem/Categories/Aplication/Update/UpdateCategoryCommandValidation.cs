using FluentValidation;

namespace SalesSystem.Categories.Aplication.Update
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
