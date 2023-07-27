namespace SalesSystem.Modules.Users.Application.CreatUserCard
{
    public record CreateUserCardCommand(string UserEmail, string CardNumber, string OwnerCard, string ExpCard, string Cvc) : IRequest<ErrorOr<Unit>>;
}
