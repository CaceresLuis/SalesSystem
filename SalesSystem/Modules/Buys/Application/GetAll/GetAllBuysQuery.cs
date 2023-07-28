using SalesSystem.Modules.Buys.Domain.Dto;

namespace SalesSystem.Modules.Buys.Application.GetAll
{
    public record GetAllBuysQuery(Guid UserId) : IRequest<ErrorOr<IReadOnlyList<BuyResponseDto>>>;
}
