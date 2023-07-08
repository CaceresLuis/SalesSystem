using SalesSystem.Modules.CartItems.Domain;

namespace SalesSystem.Modules.CartItems.Application.UpdateQyt
{
    public record UpdateCartItemQtyCommand(Guid CartItemId, int Qty) : IRequest<ErrorOr<Unit>>;
}
