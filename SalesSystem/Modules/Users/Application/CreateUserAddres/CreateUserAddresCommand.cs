namespace SalesSystem.Modules.Users.Application.CreateUserAddres
{
                            //TODO: cambiar por usuario logueado
    public record CreateUserAddresCommand(string UserEmail, string City, string Department, string AddressSpecific) : IRequest<ErrorOr<Unit>>;
}
