namespace SalesSystem.Modules.Buys.Application.Create
{
    public record CreateBuyCommand(Guid CartItemId, string UserId, Guid UserCardId, Guid UserAddressId, int Qti) : IRequest<ErrorOr<Unit>>;
}
