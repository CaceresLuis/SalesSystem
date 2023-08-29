namespace SalesSystem.Modules.TempCartItems.Application.DeleteTempCartItem
{
    public record DeleteTempCartItemCommand(Guid CartItemId) : IRequest<ErrorOr<Unit>>;
}
