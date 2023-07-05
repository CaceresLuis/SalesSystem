using SalesSystem.CartItems.Domain;

namespace SalesSystem.CartItems.Application.GetAll
{
    public record GetAllCartItemQuery(Guid CartId) : IRequest<ErrorOr<List<CartItem>>>;
}
