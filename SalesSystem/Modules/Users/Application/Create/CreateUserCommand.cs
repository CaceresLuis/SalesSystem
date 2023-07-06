namespace SalesSystem.Modules.Users.Application.Create
{
    public record CreateUserCommand(string FistName, string LastName, string Email, string Password, string PasswordConfirm, string PhoneNumber) : IRequest<ErrorOr<Unit>>;
}
