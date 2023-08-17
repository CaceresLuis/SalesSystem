using FluentValidation;

namespace SalesSystem.Modules.CartItems.Application.Delete
{
    public class DeleteCartItemCommandValidator : AbstractValidator<DeleteCartItemCommand>
    {
        public DeleteCartItemCommandValidator()
        {
            RuleFor(ci => ci.CartItemId).NotEmpty().NotNull();
        }
    }
}
