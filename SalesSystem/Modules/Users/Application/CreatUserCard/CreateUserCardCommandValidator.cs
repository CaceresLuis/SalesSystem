using FluentValidation;

namespace SalesSystem.Modules.Users.Application.CreatUserCard
{
    public class CreateUserCardCommandValidator : AbstractValidator<CreateUserCardCommand>
    {
        public CreateUserCardCommandValidator()
        {
            RuleFor(uc => uc.Cvc).NotEmpty().NotNull();
            RuleFor(uc => uc.ExpCard).NotEmpty().NotNull();
            RuleFor(uc => uc.UserEmail).NotEmpty().NotNull();
            RuleFor(uc => uc.OwnerCard).NotEmpty().NotNull();
            RuleFor(uc => uc.CardNumber).NotEmpty().NotNull();
        }
    }
}
