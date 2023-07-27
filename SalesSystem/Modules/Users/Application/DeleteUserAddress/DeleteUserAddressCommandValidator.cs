using FluentValidation;

namespace SalesSystem.Modules.Users.Application.DeleteUserAddress
{
    internal class DeleteUserAddressCommandValidator : AbstractValidator<DeleteUserAddressCommand>
    {
        public DeleteUserAddressCommandValidator()
        {
            RuleFor(ud => ud.Id).NotEmpty();
            RuleFor(ud => ud.UserEmail).NotEmpty();
        }
    }
}
