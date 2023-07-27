using SalesSystem.Shared.Domain.Primitives;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Modules.Users.Domain.DomainErrors;

namespace SalesSystem.Modules.Users.Application.DeleteUserAddress
{
    internal class DeleteUserAddressHandler : IRequestHandler<DeleteUserAddressCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserAddressHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.UserRepository.GetByEmail(request.UserEmail) is not User user)
                return ErrorsUser.UserNotFound;

            if (await _unitOfWork.UserAddressRepository.Get(request.Id, user.Id) is not UserAddres userAddres)
                return ErrorsUser.UserAddresNotFound;

            _unitOfWork.UserAddressRepository.Delete(userAddres);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
