using FluentValidation;

namespace SalesSystem.Categories.Aplication.Create
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
