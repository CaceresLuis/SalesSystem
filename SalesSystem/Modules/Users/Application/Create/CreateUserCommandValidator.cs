using FluentValidation;

namespace SalesSystem.Modules.Users.Application.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.FistName).NotEmpty().MaximumLength(150);
            RuleFor(u => u.LastName).NotEmpty().MaximumLength(150);
            RuleFor(u => u.Password).NotEmpty().MaximumLength(20);
            RuleFor(u => u.PasswordConfirm).NotEmpty().MaximumLength(20);
            RuleFor(u => u.Email).EmailAddress().NotEmpty().MaximumLength(60);
        }
    }
}
