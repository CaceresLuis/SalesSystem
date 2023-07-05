namespace SalesSystem.Modules.CartItems.Application.Create
{
    public record CreateCartItemCommad(Guid CartId, Guid ProductId, int Qty) : IRequest<ErrorOr<Unit>>;
}
