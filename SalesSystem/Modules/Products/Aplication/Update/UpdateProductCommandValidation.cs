using FluentValidation;

namespace SalesSystem.Modules.Products.Aplication.Update
{
    public class UpdateProductCommandValidation : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            RuleFor(p => p.Name)
                 .MaximumLength(100);

            RuleFor(p => p.Description)
                 .MaximumLength(255);

            RuleFor(p => p.Price)
                .PrecisionScale(5, 2, true);

            RuleFor(p => p.Stock)
                .NotNull();
        }
    }
}
