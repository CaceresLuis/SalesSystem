namespace SalesSystem.Modules.TempCartItems.Application.CreateTempCartItem
{
    public record CreateTempCartItemCommand(Guid CartId, Guid ProductId, int Qty) : IRequest<ErrorOr<string>>;
}
