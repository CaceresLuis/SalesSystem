using FluentValidation;

namespace SalesSystem.Modules.Administrator.Application.ChangeRoleUser
{
    public class ChangeRoleUserCommandValidator : AbstractValidator<ChangeRoleUserCommand>
    {
        public ChangeRoleUserCommandValidator()
        {
            RuleFor(cr => cr.Role).NotEmpty();
            RuleFor(cr => cr.UserEmail).NotEmpty();
        }
    }
}
