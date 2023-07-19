using Microsoft.AspNetCore.Identity;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Modules.Users.Domain.DomainErrors;
using SalesSystem.Modules.Users.Domain.ValueObjetcs;

namespace SalesSystem.Modules.Users.Application.Create
{
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (PhoneNumber.Create(request.PhoneNumber) is not PhoneNumber phoneNumber)
                return ErrorsUser.PhoneNumberWithBadFormat;

            User user = new
            (
                Guid.NewGuid(),
                request.Email,
                request.FistName,
                request.LastName,
                phoneNumber,
                DateTime.UtcNow,
                DateTime.MinValue,
                DateTime.MinValue,
                false,
                false
            );

            Cart cart = new(new CartId(Guid.NewGuid()), user.Id);

            IdentityResult AddUser = await _unitOfWork.UserRepository.AddAsync(user, request.Password);
            if (!AddUser.Succeeded)
                return ErrorsUser.UserError(AddUser.Errors.First().Description);

            _unitOfWork.CartRepository.Add(cart);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
