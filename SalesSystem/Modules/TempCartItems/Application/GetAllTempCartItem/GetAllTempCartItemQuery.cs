using SalesSystem.Modules.TempCartItems.Domain.Dto;

namespace SalesSystem.Modules.TempCartItems.Application.GetAllTempCartItem
{
    public record GetAllTempCartItemQuery(Guid TempUser) : IRequest<ErrorOr<IReadOnlyList<TempCartItemResponseDto>>>;
}
