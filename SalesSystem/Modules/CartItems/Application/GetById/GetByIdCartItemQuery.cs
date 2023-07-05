using SalesSystem.Modules.CartItems.Domain.Dto;

namespace SalesSystem.Modules.CartItems.Application.GetById
{
    public record GetByIdCartItemQuery(Guid Id) : IRequest<ErrorOr<CartItemResponseDto>>;
}
