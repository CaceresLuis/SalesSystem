using FluentValidation;

namespace SalesSystem.Modules.Users.Application.CreateUserAddres
{
    public class CreateUserAddresCommandValidator : AbstractValidator<CreateUserAddresCommand>
    {
        public CreateUserAddresCommandValidator()
        {
            RuleFor(ua => ua.City).NotNull().NotEmpty().MaximumLength(60);
            RuleFor(ua => ua.Department).NotNull().NotEmpty().MaximumLength(60);
            RuleFor(ua => ua.AddressSpecific).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
