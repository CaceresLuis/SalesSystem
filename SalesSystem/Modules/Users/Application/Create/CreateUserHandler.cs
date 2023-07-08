using Microsoft.AspNetCore.Identity;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Users.Domain;
using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.DomainErrors;
using SalesSystem.Modules.Users.Domain.ValueObjetcs;

namespace SalesSystem.Modules.Users.Application.Create
{
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;

        public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, ICartRepository cartRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _cartRepository = cartRepository;
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

            IdentityResult AddUser = await _userRepository.AddAsync(user, request.Password);
            if (!AddUser.Succeeded)
                return ErrorsUser.UserError(AddUser.Errors.First().Description);

            _cartRepository.Add(cart);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
