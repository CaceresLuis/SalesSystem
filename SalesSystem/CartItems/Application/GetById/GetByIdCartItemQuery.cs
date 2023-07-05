using SalesSystem.CartItems.Domain.Dto;

namespace SalesSystem.CartItems.Application.GetById
{
    public record GetByIdCartItemQuery(Guid Id) : IRequest<ErrorOr<CartItemResponseDto>>;
}
