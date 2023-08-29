namespace SalesSystem.Modules.TempCartItems.Domain.ValueObjects
{
    public class ErrorTempCartItem
    {
        public static Error NotFoundCartItem => Error.NotFound("CartItem", "Cart Item don't exist.");
    }
}
