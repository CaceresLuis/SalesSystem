using FluentValidation;

namespace SalesSystem.Modules.TempCartItems.Application.UpdateTempCartItem
{

    public class UpdateTempCartItempCommandValidation : AbstractValidator<UpdateTempCartItempCommand>
    {
        public UpdateTempCartItempCommandValidation()
        {
            RuleFor(ci => ci.Qty).ExclusiveBetween(0, 20);
            RuleFor(ci => ci.CartItemId).NotEmpty().NotNull();
        }
    }
}

