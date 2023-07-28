using FluentValidation;

namespace SalesSystem.Modules.Buys.Application.Create
{
    internal class CreateBuyCommandValidator : AbstractValidator<CreateBuyCommand>
    {
        public CreateBuyCommandValidator()
        {
            RuleFor(b => b.Qti).NotEmpty();
            RuleFor(b => b.CartItemId).NotEmpty();
            RuleFor(b => b.UserCardId).NotEmpty();
            RuleFor(b => b.UserAddressId).NotEmpty();
        }
    }
}
