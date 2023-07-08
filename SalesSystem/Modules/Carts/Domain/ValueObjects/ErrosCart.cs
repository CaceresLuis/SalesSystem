namespace SalesSystem.Modules.Carts.Domain.ValueObjects
{
    public static class ErrosCart
    {
        public static Error NotFoundCart => Error.NotFound("Cart", "Cart don't exist.");
    }
}
