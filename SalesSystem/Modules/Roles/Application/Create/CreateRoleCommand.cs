namespace SalesSystem.Modules.Roles.Application.Create
{
    public record CreateRoleCommand(string RoleName) : IRequest<ErrorOr<Unit>>;
}
