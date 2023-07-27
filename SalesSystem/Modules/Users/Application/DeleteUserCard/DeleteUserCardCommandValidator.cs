using FluentValidation;

namespace SalesSystem.Modules.Users.Application.DeleteUserCard
{
    internal class DeleteUserCardCommandValidator : AbstractValidator<DeleteUserCardCommand>
    {
        public DeleteUserCardCommandValidator()
        {
            RuleFor(ud => ud.Id).NotEmpty();
            RuleFor(ud => ud.UserEmail).NotEmpty();
        }
    }
}
