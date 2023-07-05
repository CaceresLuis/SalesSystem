using FluentValidation;

namespace SalesSystem.Modules.Products.Aplication.Create
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidation()
        {
            RuleFor(p => p.Name)
                 .NotEmpty()
                 .MaximumLength(100);

            RuleFor(p => p.Description)
                 .NotEmpty()
                 .MaximumLength(255);

            RuleFor(p => p.Price)
                .NotNull()
                .PrecisionScale(5, 2, true);

            RuleFor(p => p.Stock)
                .NotNull()
                .NotEmpty();
        }
    }
}
