using FluentValidation;

namespace SalesSystem.Modules.Users.Application.UpdateUserAddress
{
    internal class UpdateUserAddressCommandValidator : AbstractValidator<UpdateUserAddressCommand>
    {
        public UpdateUserAddressCommandValidator()
        {
            RuleFor(ud => ud.Id).NotEmpty();
            RuleFor(ud => ud.UserEmail).NotEmpty();
        }
    }
}
