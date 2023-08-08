namespace SalesSystem.Modules.Administrator.Application.Create
{
    public record CreateUserCommand(string FistName, string LastName, string Email, string Password, string PasswordConfirm, string PhoneNumber, string Role) : IRequest<ErrorOr<Unit>>;
}
