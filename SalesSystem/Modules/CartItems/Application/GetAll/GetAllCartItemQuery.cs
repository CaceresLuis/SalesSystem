using SalesSystem.Modules.CartItems.Domain;

namespace SalesSystem.Modules.CartItems.Application.GetAll
{
    public record GetAllCartItemQuery(Guid CartId) : IRequest<ErrorOr<List<CartItem>>>;
}
