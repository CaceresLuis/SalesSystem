namespace SalesSystem.Modules.CartItems.Application.Create
{
    public record CreateCartItemCommad(string CartId, Guid ProductId, int Qty) : IRequest<ErrorOr<Unit>>;
}
