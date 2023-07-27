namespace SalesSystem.Modules.Users.Application.DeleteUserAddress
{
    public record DeleteUserAddressCommand(Guid Id, string UserEmail) : IRequest<ErrorOr<Unit>>;
}
