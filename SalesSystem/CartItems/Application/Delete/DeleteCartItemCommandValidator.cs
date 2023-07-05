using FluentValidation;

namespace SalesSystem.CartItems.Application.Delete
{
    public class DeleteCartItemCommandValidator : AbstractValidator<DeleteCartItemCommand>
    {
        public DeleteCartItemCommandValidator()
        {
            RuleFor(ci => ci.CartId).NotEmpty().NotNull();
            RuleFor(ci => ci.ProductId).NotEmpty().NotNull();
        }
    }
}
