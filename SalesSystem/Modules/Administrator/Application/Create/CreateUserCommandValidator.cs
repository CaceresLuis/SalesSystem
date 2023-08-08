using FluentValidation;

namespace SalesSystem.Modules.Administrator.Application.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Role).NotEmpty();
            RuleFor(u => u.FistName).NotEmpty().MaximumLength(150);
            RuleFor(u => u.LastName).NotEmpty().MaximumLength(150);
            RuleFor(u => u.Password).NotEmpty().MaximumLength(20);
            RuleFor(u => u.PasswordConfirm).NotEmpty().MaximumLength(20);
            RuleFor(u => u.Email).EmailAddress().NotEmpty().MaximumLength(60);
        }
    }
}
