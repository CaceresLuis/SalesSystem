using SalesSystem.Modules.CartItems.Domain.Dto;

namespace SalesSystem.Modules.CartItems.Application.GetAllTempCartItemp
{
    public record GetAllTempCartItemQuery(Guid CartId) : IRequest<ErrorOr<IReadOnlyList<CartItemResponseDto>>>;
}
