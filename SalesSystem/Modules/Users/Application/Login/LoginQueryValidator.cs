using FluentValidation;

namespace SalesSystem.Modules.Users.Application.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(l => l.Password).NotEmpty();
            RuleFor(l => l.Email).EmailAddress().NotEmpty();
        }
    }
}
