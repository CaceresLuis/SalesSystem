using FluentValidation;

namespace SalesSystem.Modules.Roles.Application.Create
{
    internal class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(r => r.RoleName).NotEmpty();
        }
    }
}
