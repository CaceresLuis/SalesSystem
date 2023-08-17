namespace SalesSystem.Modules.CartItems.Application.Delete
{
    public record DeleteCartItemCommand(Guid CartItemId) : IRequest<ErrorOr<Unit>>;
}
