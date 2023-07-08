using FluentValidation;

namespace SalesSystem.Modules.CartItems.Application.UpdateQyt
{
    public class UpdateCartItemQtyCommandValidator : AbstractValidator<UpdateCartItemQtyCommand>
    {
        public UpdateCartItemQtyCommandValidator()
        {
            RuleFor(ci => ci.Qty).ExclusiveBetween(0, 20);
            RuleFor(ci => ci.CartItemId).NotEmpty().NotNull();
        }
    }
}
