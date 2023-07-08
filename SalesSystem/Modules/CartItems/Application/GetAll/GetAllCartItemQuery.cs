using SalesSystem.Modules.CartItems.Domain.Dto;

namespace SalesSystem.Modules.CartItems.Application.GetAll
{
    public record GetAllCartItemQuery(Guid CartId) : IRequest<ErrorOr<IReadOnlyList<CartItemResponseDto>>>;
}
