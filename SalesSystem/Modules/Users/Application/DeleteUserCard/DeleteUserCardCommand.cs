namespace SalesSystem.Modules.Users.Application.DeleteUserCard
{
    public record DeleteUserCardCommand(Guid Id, string UserEmail) : IRequest<ErrorOr<Unit>>;
}
