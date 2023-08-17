using FluentValidation;

namespace SalesSystem.Modules.CartItems.Application.Create
{
    public class CreateCartItemCommadValidator : AbstractValidator<CreateCartItemCommad>
    {
        public CreateCartItemCommadValidator()
        {
            RuleFor(ci => ci.Qty).ExclusiveBetween(0, 20);
            RuleFor(ci => ci.ProductId).NotNull().NotEmpty();
        }
    }
}
