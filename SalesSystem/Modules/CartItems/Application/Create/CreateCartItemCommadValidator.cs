using FluentValidation;

namespace SalesSystem.Modules.CartItems.Application.Create
{
    public class CreateCartItemCommadValidator : AbstractValidator<CreateCartItemCommad>
    {
        public CreateCartItemCommadValidator()
        {
            RuleFor(ci => ci.Qty).NotNull();
            RuleFor(ci => ci.CartId).NotNull().NotEmpty();
            RuleFor(ci => ci.ProductId).NotNull().NotEmpty();
        }
    }
}
