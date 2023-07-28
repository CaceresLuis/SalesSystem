namespace SalesSystem.Modules.Buys.Domain.ValueObjects
{
    public class ErrorBuy
    {
        public static Error NotFoundBuy => Error.NotFound("Buy", "the purchase does not exist");
        public static Error NotFoundBuys => Error.NotFound("Buys", "No purchases have been made yet");
    }
}
