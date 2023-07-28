namespace SalesSystem.Modules.CartItems.Domain.ValueObjects
{
    public class ErrorCartItem
    {
        public static Error NotFoundCartItem => Error.NotFound("CartItem", "Cart Item don't exist.");
    }
}
