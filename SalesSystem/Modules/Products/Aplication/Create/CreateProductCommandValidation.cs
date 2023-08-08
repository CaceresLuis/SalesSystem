using FluentValidation;

namespace SalesSystem.Modules.Products.Aplication.Create
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidation()
        {
            RuleFor(p => p.Name)
                 .NotEmpty()
                 .MaximumLength(150);

            RuleFor(p => p.Description)
                 .NotEmpty()
                 .MaximumLength(355);

            RuleFor(p => p.Price)
                .NotNull()
                .PrecisionScale(10, 2, false);

            RuleFor(p => p.Stock)
                .NotNull()
                .NotEmpty();
        }
    }
}
