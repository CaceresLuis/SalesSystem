namespace SalesSystem.Modules.TempCartItems.Application.UpdateTempCartItem
{
    public record UpdateTempCartItempCommand(Guid CartItemId, int Qty) : IRequest<ErrorOr<Unit>>;
}
