using FluentValidation;

namespace SalesSystem.Modules.Categories.Aplication.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.Name)
                 .NotEmpty()
                 .MaximumLength(100);
        }
    }
}
