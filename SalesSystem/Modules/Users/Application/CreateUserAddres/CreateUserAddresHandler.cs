using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Modules.Users.Domain.DomainErrors;

namespace SalesSystem.Modules.Users.Application.CreateUserAddres
{
    internal class CreateUserAddresHandler : IRequestHandler<CreateUserAddresCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserAddresHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateUserAddresCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetByEmail(request.UserEmail) is not User user)
                return ErrorsUser.UserNotFound;

            UserAddres userAddres = new
            (
                Guid.NewGuid(),
                user.Id,
                request.Department,
                request.City,
                request.AddressSpecific
            );

            _unitOfWork.UserAddressRepository.Add(userAddres);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
