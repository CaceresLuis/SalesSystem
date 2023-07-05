namespace SalesSystem.CartItems.Application.Delete
{
    public record DeleteCartItemCommand(Guid CartId, Guid ProductId) : IRequest<ErrorOr<Unit>>;
}
