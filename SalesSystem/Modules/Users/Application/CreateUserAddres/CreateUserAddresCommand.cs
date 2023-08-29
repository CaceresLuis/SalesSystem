namespace SalesSystem.Modules.Users.Application.CreateUserAddres
{
    public record CreateUserAddresCommand(string UserEmail, string City, string Department, string AddressSpecific) : IRequest<ErrorOr<Unit>>;
}
