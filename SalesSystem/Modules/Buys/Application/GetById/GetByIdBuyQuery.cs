using SalesSystem.Modules.Buys.Domain.Dto;

namespace SalesSystem.Modules.Buys.Application.GetById
{
    public record GetByIdBuyQuery(Guid BuyId) : IRequest<ErrorOr<BuyResponseDto>>;
}
