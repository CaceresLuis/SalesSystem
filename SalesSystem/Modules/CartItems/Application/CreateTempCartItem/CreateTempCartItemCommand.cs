namespace SalesSystem.Modules.CartItems.Application.CreateTempCartItem
{
    public record CreateTempCartItemCommand(string CartId, Guid ProductId, int Qty) : IRequest<ErrorOr<string>>;
}
