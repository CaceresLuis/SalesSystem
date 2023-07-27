using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Modules.Users.Domain.DomainErrors;

namespace SalesSystem.Modules.Users.Application.UpdateUserAddress
{
    internal class UpdateUserAddressHandler : IRequestHandler<UpdateUserAddressCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserAddressHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetByEmail(request.UserEmail) is not User user)
                return ErrorsUser.UserNotFound;

            if (await _unitOfWork.UserAddressRepository.Get(request.Id, user.Id) is not UserAddres userAddresDb)
                return ErrorsUser.UserAddresNotFound;

            UserAddres userAddres = new
            (
                userAddresDb.Id,
                user.Id,
                request.Department ?? userAddresDb.Department,
                request.City ?? userAddresDb.City,
                request.AddressSpecific ?? userAddresDb.AddressSpecific
            );

            _unitOfWork.UserAddressRepository.Update(userAddres);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
