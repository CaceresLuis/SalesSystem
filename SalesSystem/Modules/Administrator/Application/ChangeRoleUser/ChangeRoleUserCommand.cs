namespace SalesSystem.Modules.Administrator.Application.ChangeRoleUser
{
    public record ChangeRoleUserCommand(string Role, string UserEmail) : IRequest<ErrorOr<Unit>>;
}
